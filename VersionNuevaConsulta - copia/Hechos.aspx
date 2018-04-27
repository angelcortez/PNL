<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hechos.aspx.cs" Inherits="AtencionTemprana.Hechos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
 
    </table> 
        
<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
            </td>
        </tr>
     
      
     
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                        style="text-transform :uppercase"></asp:Label>
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
                    <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                        style="text-transform :uppercase"></asp:Label>
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
                    <asp:Label ID="ID_HECHOS" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <h2>
                        <asp:Label ID="lblOperacion" runat="server" Font-Bold="True" 
                            class="color-fuente"></asp:Label>
                    </h2>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:TextBox ID="txtDes" runat="server" Height="609px" TextMode="MultiLine" 
                        Width="1050px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td align="center" colspan="2">
                    </td>
                <td>
                    </td>
            </tr>

            <tr>
                <td>
                    </td>
                <td align="center" colspan="2">
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="UNDD0" runat="server" Font-Bold="True" Font-Size="Medium" Text="SE LE SOLICITA AL (LA) COMPARECIENTE PROPORCIONE LA SIGUIENTE INFORMACIÓN:" 
                        class="color-fuente"></asp:Label>
                    </td>
                <td align="center" colspan="2">
                    </td>
                <td>
                    </td>
            </tr>

            <tr>
                <td colspan="4" align="center">
                    <asp:TextBox ID="PreguntasPNL" runat="server" Height="400px" TextMode="MultiLine" 
                        Width="1050px" ReadOnly="True">
1.- ÚLTIMA VEZ QUE LA VIO: 
2.- PERSONA O PERSONAS QUE LA VIERON POR ÚLTIMA VEZ: 
3.- SUS ÁMBITOS SOCIAL, LABORAL, FAMILIAR, SENTIMENTAL, ECONÓMICO: 
4.- SI HA FALTADO A CASA EN ALGUNAS OCASIONES:
5.- SI CONOCE ALGÚN MOTIVO POR EL QUE SE HAYA AUSENTADO: 
6.- SI SOSPECHA DE ALGUIEN QUE SE ENCUENTRE VINCULADO A SU DESAPARICIÓN: 
7.- LOS RECORRIDOS O RUTINAS DIARIAS, ASÍ COMO LOS MEDIOS DE TRANSPORTE QUE UTILIZA, (CARACTERÍSTICAS DEL VEHÍCULO MARCA, TIPO, MODELO, COLOR, PLACAS NUMERO DE SERIE Y TODAS AQUELLAS PARTICULARIDADES QUE PUDIESEN DISTINGUIRLO EJEMPLO: GOLPES, CALCOMANÍAS, ADICIONES O CAMBIOS EN ALGUNA PARTE DE LA UNIDAD
8.- SI TIENE PAREJA SENTIMENTAL: 
9.- SI HA SIDO VÍCTIMA DE ALGÚN TIPO DE VIOLENCIA:
10.- NÚMERO DE HIJOS: 
11.- CARACTERÍSTICAS DE LAS AMISTADES QUE TIENE: 
12.- SI TIENE AMIGOS, CONOCIDOS O CONTACTOS EN EL EXTRANJERO: 
13.- SI SABE SI TIENE ENEMIGOS: 
14.- SI HA TENIDO PROBLEMAS CON ALGÚN FAMILIAR, ESPOSO, PAREJA SENTIMENTAL U OTROS: 
15.- SI SE LLEVÓ DOCUMENTOS PERSONALES, ROPA U OTRAS PERTENENCIAS: 
16.- SI CUENTA CON PASAPORTE: 
17.- SI TIENE CUENTA BANCARIA, PROPORCIONAR EL NOMBRE DE LA INSTITUCIÓN DE CRÉDITO, NUMERO DE CUENTA Y DEMÁS DATOS RELACIONADOS CON LA MISMA: 
18.- SI TIENE CONOCIMIENTO DE ALGUNA ACTITUD EXTRAÑA DIAS ANTES DE LA DESAPARICIÓN: 
19.- SI TIENE CONOCIMIENTO DE LLAMADAS O COMUNICACIONES EXTRAÑAS ANTERIORES A LA DESAPARICIÓN: 
20.- DOMICILIOS O LUGARES MAYORMENTE FRECUENTADOS POR LA PERSONA DESAPARECIDA:


</asp:TextBox>
                </td>
            </tr>



            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp; &nbsp;
                    <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" style="display:none"
                        Text="GUARDAR" Width="156px" Font-Bold="True" Height="40px" class="button" />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" onclick="cmdReg_Click" Text="REGRESAR" 
                        Width="156px" Font-Bold="True" Height="40px" class="button" />
                    &nbsp;
                </td>
            </tr>
        </table>

    </ContentTemplate>
    </asp:UpdatePanel>
  
  
    
    
</div>

</asp:Content>

