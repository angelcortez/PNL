<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PNLSeniasParticulares.aspx.cs" Inherits="AtencionTemprana.PNLSeniasParticulares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
        }
        .style3
        {
            width: 734px;
            height: 887px;
        }
        .style4
        {
            width: 151px;
        }
        .style5
        {
            width: 151px;
            height: 90px;
        }
        .style7
        {
        }
        .style8
        {
            width: 333px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
    <div id="main-wrapper">
    <asp:ScriptManager ID="sc" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
     <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
            </td>
            <td>

                </td>
            <td>
                </td>
            <td>
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
         <tr>
             <td>
                 <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
                 <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#666666" 
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
                     <asp:Label ID="IdUsuario" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                 <asp:Label ID="IDtIPOuNIDAD" runat="server" Text=" " Visible="false"></asp:Label>
                  <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                 <asp:Label ID="ID_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                 <asp:Label ID="ID_MUNICIPIO_CARPETA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                 <asp:Label ID="ID_SENIAS_PARTICULARES" runat="server" ForeColor="Red" Visible="false"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td align="right">
                 &nbsp;</td>
         </tr>
     
      
    </table>

     
           <div class="welcome">
               <h1>
                   <asp:Label ID="lblOperacion" runat="server" class="color-fuente" Text="SEÑAS PARTICULARES"></asp:Label></h1>
               <p>
                   &nbsp;</p>
             <table style="width: 100%;">
                   <tr>
               <td colspan="4">
                   <asp:Label ID="Label60" runat="server" Font-Bold="True" Font-Italic="True" 
                       ForeColor="Black" Text="OFENDIDO"></asp:Label>
               </td>
               </tr>
                   <tr>
                       <td colspan="4">
                           <asp:DropDownList ID="ddlOfendido" runat="server" Width="400px">
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="4">
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td colspan="4">
                           &nbsp;</td>
                   </tr>
                   
                   <tr>
                       <td class="style7" >
                           <asp:Label ID="Label59" runat="server" Font-Bold="True" Font-Italic="False" 
                               Font-Size="Small" ForeColor="Black" Text="TIPO DE SEÑA"></asp:Label>
                           </td>
                       <td class="style4" >
                           <asp:Label ID="Label79" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="DESCRIPCION DE SEÑA"></asp:Label>
                       </td>
                       <td class="style8" >
                           <asp:Label ID="Label80" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="VISTA"></asp:Label>
                       </td>
                       <td >
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style7" >
                           <asp:DropDownList ID="ddlTipoSeña" runat="server" Width="200px" class="chosen-select">
                           </asp:DropDownList>
                       </td>
                       <td class="style4" >
                           <asp:DropDownList ID="ddlDescripcionSeña" runat="server" Width="200px" class="chosen-select">
                           </asp:DropDownList>
                       </td>
                       <td class="style8" >
                           <asp:DropDownList ID="ddlVista" runat="server" Width="200px" class="chosen-select">
                           </asp:DropDownList>
                       </td>
                       <td >
                           &nbsp;</td>
                   </tr>
                  
                   <tr>
                       <td class="style7" >
                           &nbsp;</td>
                       <td class="style4" >
                           &nbsp;</td>
                       <td class="style8" >
                           &nbsp;</td>
                       <td >
                           &nbsp;</td>
                   </tr>
                    <tr>
                       <td class="style7">
                           <asp:Label ID="Label71" runat="server" Font-Bold="True" Font-Italic="False" 
                               Font-Size="Small" ForeColor="Black" Text="LADO"></asp:Label>
                           <br />
                           <br />
                           <asp:DropDownList ID="ddlLado" runat="server" Width="200px" class="chosen-select">
                           </asp:DropDownList>
                        </td>
                       <td class="style5">
                           <asp:Label ID="Label77" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="REGIÓN (número)"></asp:Label>
                           <br />
                           <br />
                           <asp:DropDownList ID="ddlRegion" runat="server" Width="200px" class="chosen-select">
                           </asp:DropDownList>
                        </td>
                       <td class="style8">
                           <asp:Label ID="Label78" runat="server" Font-Bold="True" Font-Size="Small" 
                               ForeColor="Black" Text="CANTIDAD"></asp:Label>
                           <br />
                           <br />
                           <asp:DropDownList ID="ddlCantidad" runat="server" Width="200px" class="chosen-select">
                           </asp:DropDownList>
                        </td>
                       <td >
                           &nbsp;</td>
                   </tr>
                    
                    <tr>
                       <td class="style7" >
                           <br />
                           <asp:Label ID="Label66" runat="server" Font-Bold="True" Font-Italic="False" 
                               ForeColor="Black" Text="DESCRIPCIÓN" Font-Size="Small"></asp:Label>
                           <br />
                        </td>
                       <td class="style4" >
                           &nbsp;</td>
                       <td class="style8">
                           &nbsp;</td>
                       <td class="style18">
                           &nbsp;</td>
                   </tr>
                    <tr>
                       <td class="style2" colspan="4">
                           <asp:TextBox ID="txtObservaciones" runat="server" Height="83px" TextMode="MultiLine" 
                               Width="937px" style="text-transform :uppercase" MaxLength="8000"></asp:TextBox>
                        </td>
                   </tr>
                    <tr>
                       <td class="style7" align="center" colspan="4">
                           &nbsp;</td>
                   </tr>
                    <tr>
                        <td align="center" class="style7" colspan="4">
                            <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                                ForeColor="Red"></asp:Label>
                        </td>
                   </tr>
                   <tr>
                       <td align="center" class="style7" colspan="4">
                           <asp:Button ID="cmdGuardar" runat="server" Height="40px" 
                               onclick="cmdGuardar_Click" Text="GUARDAR" Width="156px" class="button"  />
                           &nbsp;<asp:Button ID="cmdregresar" runat="server" Height="40px" 
                               onclick="cmdregresar_Click" Text="REGRESAR" Width="156px" class="button" />
                       </td>
                   </tr>
                    <tr>
                       <td class="style2" colspan="4" align="center">
                           &nbsp;
                           <img alt="" class="style3" 
                               src="img/monitodoble.jpg" />
                       </td>
                   </tr>
               </table>
           </div>
    </ContentTemplate>
    </asp:UpdatePanel>

          
        </div>
</asp:Content>
