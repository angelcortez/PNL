<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MediaFiliacionDetenido.aspx.cs" Inherits="TarjetaInformativa.MediaFiliacionOfendido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style14
        {
        }
        .style16
        {
            height: 1px;
        }
        </style>
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
            <td class="style3">
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#006600"></asp:Label>
            </td>
            <td class="style3">
                </td>
            <td class="style3">
                </td>
            <td align="right" class="style3">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
         <tr>
             <td>
                 <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                     style="text-transform :uppercase"></asp:Label>
             </td>
             <td>
                 <asp:Label ID="IdCarpeta" runat="server" ForeColor="Red" Visible="false"></asp:Label>
             </td>
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
                 <asp:Label ID="ID_MEDIA_FILIACION" runat="server" Visible="FALSE" ></asp:Label>
                 <asp:Label ID="IDtIPOuNIDAD" runat="server" Text=" " Visible="false"></asp:Label>
                  <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="false"></asp:Label>
             </td>
             <td>
                 <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td align="right">
                 &nbsp;</td>
         </tr>
     
      
    </table>
           

               <h1>
                   <asp:Label ID="lblOperacion" runat="server" Text="MEDIA FILIACIÓN"></asp:Label></h1>
               <p>
                   &nbsp;</p>
               <table style="width: 100%;">
               <tr>
               <td colspan="4">
                   <asp:Label ID="Label60" runat="server" Font-Bold="True" Font-Italic="True" 
                       ForeColor="Black" Text="IMPUTADO"></asp:Label>
               </td>
               </tr>
                   <tr>
                       <td colspan="4">
                           <asp:DropDownList ID="ddlImputado" runat="server" Width="400px">
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
                       <td class="style14">
                           <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" 
                               ForeColor="Black" Text="COMPLEXIÓN"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" 
                               ForeColor="Black" Text="COLOR DE PIEL"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" 
                               ForeColor="Black" Text="CARA"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlComplecion" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlColorPiel" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlCara" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td class="style14">
                           <asp:Label ID="Label5" runat="server" Text="CABELLO" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style16" bgcolor="#FF6600" colspan="6">
                           </td>
                   </tr>
                     <tr>
                       <td class="style14">
                           <asp:Label ID="Label6" runat="server" Text="CANTIDAD" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label7" runat="server" Text="COLOR" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label8" runat="server" Text="FORMA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label9" runat="server" Text="CALIVICIE" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
&nbsp;</td>
                       <td class="style14">
                           <asp:Label ID="Label10" runat="server" Text="IMPLANTACIÓN" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
&nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                     <tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlCantidadCabello" runat="server" Width="130px">
                           </asp:DropDownList>
                         </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlColorCabello" runat="server" Width="130px">
                           </asp:DropDownList>
                         </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlFormaCabello" runat="server" Width="130px">
                           </asp:DropDownList>
                         </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlCalvicieCabello" runat="server" Width="130px">
                           </asp:DropDownList>
&nbsp;</td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlImplantacionCabello" runat="server" Width="130px"  >
                           </asp:DropDownList>
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                     <tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
                     <tr>
                       <td class="style14">
                           <asp:Label ID="Label12" runat="server" Text="FRENTE" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                         </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           <asp:Label ID="Label21" runat="server" Text="OJOS" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                     <tr>
                       <td class="style16" bgcolor="#FF6600" colspan="6">
                           </td>
                       <tr>
                       <td class="style14">
                           <asp:Label ID="Label13" runat="server" Text="ALTURA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label14" runat="server" Text="INCLINACIÓN" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label15" runat="server" Text="ANCHO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label22" runat="server" Text="COLOR" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
&nbsp;</td>
                       <td class="style14">
                           <asp:Label ID="Label23" runat="server" Text="FORMA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label24" runat="server" Text="TAMAÑO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                           &nbsp;
                           </td>
  <tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlAlturaFrente" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlInclinacionFrente" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlAnchoFrente" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlColorOjos" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlFormaOjos" runat="server" Width="130px">
                           </asp:DropDownList>
                           &nbsp;
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlTamañoOjos" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
  <tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
  <tr>
                       <td class="style14">
                           <asp:Label ID="Label16" runat="server" Text="CEJAS" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                         </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           <asp:Label ID="Label32" runat="server" Text="BOCA" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td>
                           &nbsp;</td>
                   </tr>
  <tr>
                       <td class="style16" bgcolor="#FF6600" colspan="6">
                           </td>
                   </tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label17" runat="server" Text="DIRECCIÓN" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label18" runat="server" Text="IMPLANTACIÓN" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label19" runat="server" Text="FORMA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label20" runat="server" Text="TAMAÑO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label30" runat="server" Text="TAMAÑO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label31" runat="server" Text="COMISURAS" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlDireccionCejas" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlImplantacionCejas" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlFormaCejas" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlTamañoCejas" runat="server" Width="130px">
                           </asp:DropDownList>
&nbsp;</td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlTamañoBoca" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlComisurasBoca" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
</tr>
<tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label25" runat="server" Text="NARIZ" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style16" bgcolor="#FF6600" colspan="6">
                           </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label59" runat="server" Font-Bold="True" Font-Italic="True" 
                               ForeColor="Black" Text="RAÍZ(Prof.)"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label26" runat="server" Text="DORSO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label27" runat="server" Text="ANCHO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label28" runat="server" Text="BASE" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label29" runat="server" Text="ALTURA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlRaizNariz" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlDorsoNariz" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlAnchoNariz" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlBaseNariz" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlAlturaNariz" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label33" runat="server" Text="LABIOS" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           <asp:Label ID="Label40" runat="server" Text="MENTON" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style16" bgcolor="#FF6600" colspan="6">
                           </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label34" runat="server" Text="ESPESOR" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label35" runat="server" Text="ALTURA NASO-LABIAL" 
                               Font-Bold="True" Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label36" runat="server" Text="PROMINENCIA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label37" runat="server" Text="TIPO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label38" runat="server" Text="FORMA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td>
                           <asp:Label ID="Label39" runat="server" Text="INCLINACIÓN" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlEspesorLabios" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlNasoLabial" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlProminenciaLabial" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlTipoMenton" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlFormaMenton" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td>
                           <asp:DropDownList ID="ddlInclinacionMenton" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
</tr>
<tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label41" runat="server" Text="OREJA DERECHA" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           <asp:Label ID="Label48" runat="server" Text="HÉLIX" Font-Bold="True" 
                               ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style16" bgcolor="#FF6600" colspan="6">
                           </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label42" runat="server" Text="FORMA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label43" runat="server" Text="ORIGINAL" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label44" runat="server" Text="SUPERIOR" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label45" runat="server" Text="POSTERIOR" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
&nbsp;</td>
                       <td class="style14">
                           <asp:Label ID="Label46" runat="server" Text="ADHERENCIA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
&nbsp;</td>
                       <td>
                           &nbsp;
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlFormaOreja" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlOriginalOreja" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlSuperiorHelix" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlPosteriorHelix" runat="server" Width="130px">
                           </asp:DropDownList>
&nbsp;</td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlAdherenciaHelix" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td>
                           &nbsp;
                       </td>
</tr>
<tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label47" runat="server" Text="LOBULO" Font-Bold="True" 
                               ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;
                       </td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label49" runat="server" Text="CONTORNO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label50" runat="server" Text="ADHERENCIA" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label51" runat="server" Text="PARTICULARIDAD" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label52" runat="server" Text="DIMENSIÓN" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlContornoLobulo" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlAdherenciaLobulo" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlParticularidadLobulo" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlDimensionLobulo" runat="server" Width="130px">
                           </asp:DropDownList>
                           &nbsp;
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style14">
                           <asp:Label ID="Label53" runat="server" Text="SANGRE" Font-Bold="True" 
                               Font-Size="Small" ForeColor="#006600"></asp:Label>
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
<tr>
                       <td class="style16" bgcolor="#FF6600" colspan="6">
                       </td>
</tr>
  
<tr>
                       <td class="style14">
                           <asp:Label ID="Label54" runat="server" Text="TIPO" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label55" runat="server" Text="FACTOR RH" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label56" runat="server" Text="USA ANTEOJOS" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label57" runat="server" Text="ESTATURA(cm)" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td class="style14">
                           <asp:Label ID="Label58" runat="server" Text="PESO(kg)" Font-Bold="True" 
                               Font-Italic="True" ForeColor="Black"></asp:Label>
                       </td>
                       <td>
                           &nbsp;</td>
</tr>
  
<tr>
                       <td class="style14">
                           <asp:DropDownList ID="ddlTipoSangre" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlFactarSangre" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:DropDownList ID="ddlAnteojos" runat="server" Width="130px">
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                           <asp:TextBox ID="txtEstatura" runat="server" Width="130px" MaxLength="6"></asp:TextBox>
                       </td>
                       <td class="style14">
                           <asp:TextBox ID="txtPeso" runat="server" Width="130px"></asp:TextBox>
                       </td>
                       <td>
                           &nbsp;</td>
</tr>
  
<tr>
                       <td class="style14">
                           <br />
                           <br />
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
  
<tr>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14">
                           &nbsp;</td>
                       <td class="style14" align="center" colspan="2">
                           <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" Width="156px" Height="40px" 
                               onclick="cmdGuardar_Click" />
&nbsp;<asp:Button ID="cmdRegresar" runat="server" Text="REGRESAR" onclick="cmdRegresar_Click" Width="156px" Height="40px"  />
                       </td>
                       <td class="style14">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
</tr>
  
               </table>



             
           </div>
    </ContentTemplate>
    </asp:UpdatePanel> 
      
     </div>
</asp:Content>

