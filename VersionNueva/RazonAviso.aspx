<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RazonAviso.aspx.cs" Inherits="AtencionTemprana.RazonAviso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
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
     
      
    </table>

     <h2>
         &nbsp;</h2>
        <table style="width: 100%;">
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
            <tr>
                <td>
                    <asp:Button ID="cmdRazonConDet" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="#006600" Height="61px" 
                        onclick="cmdRazonConDet_Click" Text="RAZON DE AVISO CON DETENIDO" 
                        Width="243px" />
                    <asp:ImageButton ID="ImageButton3" runat="server" Height="61px" 
                        ImageAlign="Middle" ImageUrl="~/img/condetenido.jpg" 
                         Width="71px" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="cmdRazonSinDet" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="#006600" Height="61px" 
                        onclick="cmdRazonSinDet_Click" Text="RAZON DE AVISO SIN DETENIDO" 
                        Width="243px" />
                    <asp:ImageButton ID="ImageButton4" runat="server" Height="61px" 
                        ImageAlign="Middle" ImageUrl="~/img/hospital.png" Width="71px" />
                </td>
                <td>
                    &nbsp;
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
    
    </ContentTemplate>
    </asp:UpdatePanel>  
    
</div>

</asp:Content>

