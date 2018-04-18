<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormaInicioNuc.aspx.cs" Inherits="AtencionTemprana.FormaInicioNuc" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 65px;
        }
        .style3
        {
            height: 97px;
        }
    </style>
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

   <asp:Label ID="lblMensajeSession" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente" Visible=false></asp:Label>

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
                    <asp:Panel ID="Panel2" runat="server" >
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
                                        ForeColor="#006600" Text="FORMA DE INICIO"></asp:Label>
                                    <asp:Label ID="IdCarpetaInicio" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblArbol" runat="server" Visible="False">4</asp:Label>
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
                            <tr>
                                <td>
                                    <asp:Button ID="cmdCompa" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="White" Height="61px" onclick="cmdCompa_Click" Text="COMPARECENCIA" 
                                        Width="234px" class="button" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="61px" 
                                        ImageAlign="Middle" ImageUrl="~/img/Persona comparecencia.png" Width="71px" />
                                </td>
                                <td>
                                    <asp:Button ID="cmdEscrito" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="White" Height="61px" onclick="cmdEscrito_Click" Text="ESCRITO" 
                                        Width="233px" class="button"/>
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="60px" 
                                        ImageAlign="Middle" ImageUrl="~/img/IconoLibro.png" Width="71px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Button ID="cmdInforme" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="White" Height="61px" onclick="cmdInforme_Click" 
                                        Text="INFORME POLICIAL" Width="234px" class="button" />
                                </td>
                                <td class="style2">
                                    <asp:Button ID="cmdRazon" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="White" Height="61px" onclick="cmdRazon_Click" 
                                        Text="RAZON DE AVISO" Width="233px" class="button"/>
                                </td>
                                <td class="style2">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <asp:Button ID="cmdIncompetencia" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="White" Height="61px" 
                                        Text="INCOMPETENCIA" Width="234px" onclick="cmdIncompetencia_Click" class="button"/>
                                </td>
                                <td>
                                    <br />
                                    <asp:Button ID="cmdAccidenteVial" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="White" Height="61px"  
                                        Text="PARTE DE ACCIDENTE VIAL" Width="234px" 
                                        onclick="cmdAccidenteVial_Click" class="button"/>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                     <asp:Button ID="btnDenunciaAnonima"  runat="server" Font-Bold="True"  
                                        Font-Size="Small"  Height="61px" 
                                 Text="DENUNCIA ANONIMA" Width="234px"   CssClass ="button" 
                                         onclick="btnDenunciaAnonima_Click"  />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server" style="text-align: center" >
                        <table style="width:100%;">
                            <tr>
                                <td align="center" colspan="3" class="style3">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" 
                                        ForeColor="#006600" Text="INICIAR NUMERO UNICO DE CARPETA"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="NUMERO" Visible="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="AÑO" Visible="False"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FECHA INICIO" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:TextBox ID="txtNumero" runat="server" MaxLength="4" Width="200px" 
                                        TabIndex="1" Visible="False"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAño" runat="server" MaxLength="4" Width="200px" 
                                        TabIndex="2" Visible="False"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Width="200px" 
                                        TabIndex="3" Visible="False"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                                        ForeColor="Red" />
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblIniciar" runat="server" ForeColor="#006600" 
                            style="font-weight: 700; font-size: large; text-align: left;" 
                            Text="¿HAY DETENIDO?"></asp:Label>
                                <br />
                                &nbsp;<br />
                                <asp:ImageButton ID="ImgSi" runat="server" ImageUrl="~/img/si.png" 
                            onclick="ImgSi_Click" TabIndex="4" />
                        &nbsp;<asp:ImageButton ID="ImgNo" runat="server" ImageUrl="~/img/no.png" 
                            onclick="ImgNo_Click" />
                    </asp:Panel>
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

