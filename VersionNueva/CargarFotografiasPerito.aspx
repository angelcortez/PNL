<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CargarFotografiasPerito.aspx.cs" Inherits="AtencionTemprana.CargarFotografiasPerito" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .margen
        {
            margin: 5px;    
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
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="IdUsuario" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="IdSP" runat="server" Visible="False" ></asp:Label>
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
                 <asp:ImageButton ID="IBEliminar" runat="server" Height="18px" 
                        ImageUrl="img/foto.jpg" onclick="IBEliminar_Click" Width="18px" />
                     <asp:Label ID="Label1" Text="ELIMINAR IMÁGENES" runat="server" 
                        Font-Bold="True" Font-Size="18px" ForeColor="#666666" 
                        style="text-transform :uppercase" class="margen"></asp:Label>    
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                    <br />
                    <h2> CARGAR IMÁGEN </h2>
                </td>
            </tr>  
            <tr>
                <td >
                    <asp:Label ID="Titulo" runat="server" Text="Título" class="margen" 
                        Font-Size="14pt"></asp:Label>
                    <asp:TextBox ID="txtTitulo" runat="server" Width="228px" class="margen"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Descripcion" runat="server" Text="Descripción" class="margen" 
                        Font-Size="14pt"></asp:Label>
                    <asp:TextBox ID="txtdescripcion" runat="server" Width="228px" class="margen"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Seleccionar" class="margen" Font-Size="14"></asp:Label>
                    <asp:FileUpload ID="ImagenFile" runat="server"  class="margen"/>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                        Text="GUARDAR IMÁGEN" />
                </td>
            </tr> 
            <tr>
               <td class="style8"  >
                           <br />
                          <asp:Image ID="Ifoto" runat="server" Height="250px" ImageAlign="Middle" 
                              style="margin: 10px;" Width="500px"  />
                           <br />
                           &nbsp;&nbsp;&nbsp;
                           <asp:ImageButton ID="IBDelete" runat="server" Height="18px" 
                        ImageUrl="img/eliminar.png" onclick="IBDelete_Click" Width="18px"/>
                        <asp:Label ID="lblEliminar" runat="server"
                               Text="ELIMINAR IMÁGEN"></asp:Label>
                </td>
            </tr>            
        </table>
                
    
   

       


              

    </ContentTemplate>
    </asp:UpdatePanel>

    
    
    
</div>

</asp:Content>
