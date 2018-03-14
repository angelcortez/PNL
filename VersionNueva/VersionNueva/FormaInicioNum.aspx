<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormaInicioNum.aspx.cs" Inherits="AtencionTemprana.FormaInicioNum" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
    
        <table style="width: 100%;">
            <tr>
                <td colspan="4">
                    &nbsp;
                    &nbsp;
                    &nbsp;
                    <asp:Panel ID="Panel2" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <h2>
                                        <asp:Label ID="Label1" runat="server" ForeColor="#006600" 
                                            Text="FORMA DE INICIO"></asp:Label>
                                    </h2>
                                </td>
                                <td>
                                    <asp:Label ID="IdCarpetaInicio" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td>
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
                                    <asp:Button ID="cmdEscrito" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="#006600" Height="61px" onclick="cmdEscrito_Click" Text="ESCRITO" 
                                        Width="233px" />
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="60px" 
                                        ImageAlign="Middle" ImageUrl="~/img/IconoLibro.png" Width="71px" />
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
                    <asp:Panel ID="Panel1" runat="server" BorderWidth="2px" ForeColor="Green">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                                        ForeColor="#006600" Text="NUMERO DE NUM"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="NUMERO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="AÑO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="FECHA INICIO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNumero" runat="server" MaxLength="4" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtNumero" Display="Dynamic" ErrorMessage="INGRESA NUMERO" 
                                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAño" runat="server" MaxLength="4" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtAño" Display="Dynamic" ErrorMessage="INGRESA AÑO" 
                                        Font-Bold="True" Font-Size="Medium" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txtFechaInicio" Display="Dynamic" 
                                        ErrorMessage="INGRESA FECHA" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                                        ForeColor="Red" />
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:ImageButton ID="ImgSi" runat="server" ImageUrl="~/img/si.png" 
                                        onclick="ImgSi_Click" />
                                    <asp:ImageButton ID="ImgNo" runat="server" ImageUrl="~/img/no.png" 
                                        onclick="ImgNo_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    
                   
                
                   


                   
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

