<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarAnexo.aspx.cs" Inherits="AtencionTemprana.CargarAnexo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
     .hidden
     {
         display:none;
     }
</style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
         
        
<div id="main-wrapper">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="cmdGuardar" />
    </Triggers>
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
         </tr>
     
      
         <tr>
             <td>
                 <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                     style="text-transform :uppercase"></asp:Label>
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdOrden" runat="server" Visible="false"></asp:Label>
             </td>
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
                <td>
                    <br />
                    <asp:ImageButton ID="IBOrden" runat="server" Height="18px" 
                        ImageUrl="img/ordenes.png" onclick="IBOrden_Click" Width="18px" />
                     <asp:Label ID="lblMisOrdenes" Text="ORDEN" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                </td>
            </tr>
        <tr>
             <td colspan="2">
                 <br />
                 <br />
                 <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" 
                     Text="CARGAR ANEXO" style="font-size:20px"></asp:Label>
                 &nbsp;
                 <asp:Label ID="lblIdUsuario" runat="server" Text="" Visible="False"></asp:Label>
                 <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                 <br />
                 <br />
             </td>
             <td>
                 &nbsp;
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             
             
             </tr>
             <tr>
            <td colspan="3">
            <br />
                    <asp:Label ID="Label332" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SELECCIONE DOCUMENTO PDF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            
                 <asp:FileUpload ID="FileUpload1" runat="server" />  <asp:Label ID="Label2" runat="server"></asp:Label>
                 <br />
                  <br />
                <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                         Text="GUARDAR" />
                     <asp:Label ID="Label4" runat="server" Text=" "></asp:Label>
            </td>
        </tr>
        </table>
                    

    </ContentTemplate>
    </asp:UpdatePanel>

    
    
    
</div>

</asp:Content>

