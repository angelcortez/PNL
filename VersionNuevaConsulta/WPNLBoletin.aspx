<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WPNLBoletin.aspx.cs" Inherits="AtencionTemprana.WPNLBoletin" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 22px;
        }
    </style>

        <script type="text/javascript">
            function mostrarFichero(destino) {
                window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
                document.forms(0).submit();
            }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
   
   <div id="main-wrapper">
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
            <td class="style2">
                <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
            <td align="right" class="style2">
                </td>
        </tr>
     
      
        <tr>
            <td class="style2">
                <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
            <td class="style2">
                </td>
            <td class="style2">
                </td>
            <td align="right" class="style2">
                </td>
        </tr>
    </table>  
    <br />
    <asp:Panel ID="Panel3" runat="server" GroupingText="BOLETIN"  Font-Bold="True" Font-Size="Medium">
        <table>
            <tr>
            <td><asp:Label ID="lblOfendido" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"   Text="PERSONA"></asp:Label></td>
            <td><asp:Label ID="lblTipoBoletin" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"   Text="TIPO DE BOLETIN"></asp:Label> </td>
            <td><asp:Label ID="lblFoto" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"   Text="FOTO"></asp:Label> </td>
            <td><asp:Label ID="lblNumero" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"   Text="NÚMERO DE REPORTE" Visible=false></asp:Label> </td>
            </tr>
            <tr>
            <td><asp:DropDownList ID="ddlOfendido" runat="server" Width="300px" 
                    AutoPostBack="True" onselectedindexchanged="ddlOfendido_SelectedIndexChanged"></asp:DropDownList></td>
            <td><asp:DropDownList ID="ddlTipoBoletin" runat="server" Width="300px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlTipoBoletin_SelectedIndexChanged" ></asp:DropDownList></td>
            <td><asp:DropDownList ID="ddlFoto" runat="server" Width="300px" AutoPostBack="True" 
                    onselectedindexchanged="ddlFoto_SelectedIndexChanged"></asp:DropDownList></td>
            <td><asp:TextBox ID="txtNumero" runat="server" MaxLength="20" Width="132px" 
                    name="txtNumero" Visible=false></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblFormato" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"   Text="FORMATO DEL BOLETIN"></asp:Label></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlFormatoBoletin" runat="server" AutoPostBack="True"  Width="300px">
                        <asp:ListItem Value="0">--SELECCIONE--</asp:ListItem>
                        <asp:ListItem Value="1">PDF</asp:ListItem>
                        <asp:ListItem Value="2">IMAGEN</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"   Text="VISTA PREVIA DE LA FOTO"></asp:Label>
        <br />
        <asp:Image ID="ImagePNL" runat="server" Height="157px" Width="147px" />
        <br />
       
     </asp:Panel>
     <br />

     <div align=center>
            <asp:Button ID="btnGuardarDatos" runat="server" Text="GENERAR BOLETIN"  
             Height="40px" Width="156px" class="button" 
                onclick="btnGuardarDatos_Click"   OnClientClick="this.disabled=true;this.value = 'GUARDANDO DATOS...'" UseSubmitBehavior="false"/>&nbsp;
             <asp:Button ID="btnRegresar" runat="server" Text="REGRESAR"  
             Height="40px" Width="156px" class="button" 
             onclick="btnRegresar_Click"    />
             &nbsp;
               <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium"   ForeColor="Red" Visible="true"></asp:Label>
            <br />
            <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium"   ForeColor="Red" ></asp:Label>
            <br />
            <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium"  ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"   ForeColor="Red"></asp:Label>
                       
       </div>
       <asp:Panel ID="pnlPerson" runat="server">

           <br />
           <br />
           <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ShowBackButton="False" 
                        ShowZoomControl="False" style="margin-right: 0px" 
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1000px" Visible=false>
           </rsweb:ReportViewer>
           <br />
           <br />
</asp:Panel>
</div>

</asp:Content>
