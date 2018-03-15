﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenCoordPoliciaInvestigador.aspx.cs" Inherits="AtencionTemprana.OrdenCoorPoliciaInvestigador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function mostrarFichero(destino) {
        window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
        document.forms(0).submit();
    }
    
    </script>


<style>
        .margen 
        {
            margin:5px
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
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Font-Size="Medium"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                    ForeColor="Black"></asp:Label>
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
                      <asp:Label ID="IdUsuario" runat="server" Visible="False"></asp:Label>
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
                <asp:Label ID="lblArbol" runat="server" Visible="False">6</asp:Label>
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
                    <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="ID_ESTADO_NUC" runat="server" Visible="False"></asp:Label>
             </td>
        </tr>
        <tr>
                <td>
                    
                            <asp:ImageButton ID="Image2" runat="server" Height="18px" 
                        ImageUrl="img/home.png" onclick="Image2_Click" />
                            <asp:Label ID="lblInicio" Text="INICIO" runat="server" Font-Bold="True"  Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                    
            
                 
                            <asp:ImageButton ID="Image1" runat="server" Height="18px" 
                                ImageUrl="img/ordenes.png" onclick="Image1_Click" />
                            <asp:Label ID="lblMisOrdenes" Text="MIS ORDENES" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase" class="margen"></asp:Label>    
                    
                    
                    <!--
                    <a href='ElaborarInformePolicial.aspx' class="margen">
                            <asp:Image ID="Image3" runat="server" Height="18px" ImageUrl="img/document.png" />   
                            <asp:Label ID="lblPerito" Text="ELABORAR INFORME POLICIAL" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                    </a>
                    <a href='SolicitudPeritosC.aspx' class="margen">
                            <asp:Image ID="Image4" runat="server" Height="18px" ImageUrl="img/perito.png" />   
                            <asp:Label ID="Label1" Text="SOLICITAR PERITO" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                    </a>
                    -->
                    <br />
                    <br />
                </td>
            </tr>
        <tr>
            <td colspan="5" class="style5">
                <asp:Panel ID="Panel6" runat="server" Height="758px" ScrollBars="Auto">
                    <br />
                    <asp:TreeView ID="TVCarpeta" runat="server" Height="151px" ImageSet="Simple" 
                        Width="927px">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                            HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <RootNodeStyle Font-Bold="True" ForeColor="#CC0000" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                            HorizontalPadding="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </asp:Panel>
                <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="Red"></asp:Label>
                <br />
            </td>
        </tr>
       
    </table>
    
  </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>
