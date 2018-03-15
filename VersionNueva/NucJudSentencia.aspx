<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NucJudSentencia.aspx.cs" Inherits="AtencionTemprana.NucJudSentencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function mostrarFichero(destino) {
            window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
            document.forms(0).submit();
        }
    
    </script>
<style>
        .hidden
         {
            display:none;
         }
        .margen 
        {
            margin:5px
        }
        #Radio1
    {
        width: 131px;
    }
        .style6
    {
        width: 230px;
        text-align: left;
        height: 19px;
    }
        .style7
    {
        text-align: center;
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
   <%-- <asp:PostBackTrigger ControlID="cmdElaborarInforme" />
    <asp:PostBackTrigger ControlID="cmdGuardar" />--%>
    </Triggers>
    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;<asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
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
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                </td>
            <td>
                &nbsp;
            </td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblArbol" runat="server" Visible="False">4</asp:Label>
            </td>
            <td>
                  </td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="PUESTO" runat="server" Font-Bold="True" 
                    ForeColor="#666666" style="text-transform :uppercase"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        </table>
        </tr>
        </table>
        <p>
            &nbsp;</p>
      <table style="width: 100%;" runat="server" id="tbl_informe">
      <tr>
            <td>
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                </td>
            <td>
                    &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        </table>

          <br />
        <table style="width:100%;">
            <tr>
                <td class="style7">
                    <strong><span class="style15" style="font-size: medium; color: #0066CC;">Datos de la Sentencia</span></strong></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:TextBox ID="TxtSentencia" runat="server" Font-Size="Medium" Height="295px" 
                        ReadOnly="True" TextMode="MultiLine" Width="1086px"></asp:TextBox>
                </td>
            </tr>
            <tr>

                <td>
                    <br />
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="CmdRegresar" runat="server" CssClass="button" Height="26px" 
                        OnClick="CmdRegresar_Click" TabIndex="12" Text="&lt;&lt; Regresar" 
                        Width="212px" />
                </td>
            </tr>
        </table>

        <br />
    
  </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>
