<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RazonAvisoSinDetenido.aspx.cs" Inherits="AtencionTemprana.RazonAvisoSinDetenido" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 17px;
        }
        .style4
        {
            width: 138px;
        }
        .style5
        {
            width: 189px;
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
        

     <h2> 
         <asp:Label ID="lblOperacion" runat="server" ForeColor="#006600"></asp:Label></h2>
        <table style="width: 100%;">
        <tr>
                <td>
                    <asp:Label ID="IdRazon" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ID_CARPETA" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" colspan="4">
                    <asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" 
                        Width="925px">
                        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1">
                            <HeaderTemplate>
                                ¿QUIEN AVISA?
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td class="style5">
                                            <asp:RadioButtonList ID="rbAvisa" runat="server" AutoPostBack="True" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Black" 
                                                onselectedindexchanged="rbAvisa_SelectedIndexChanged">
                                                <asp:ListItem  Value="1">HOSPITAL</asp:ListItem>
                                                <asp:ListItem Value="2">CORPORACION</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td class="style4">
                                            <asp:DropDownList ID="ddlHospital" runat="server" Enabled="False" Width="300px">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlCorporacion" runat="server" Enabled="False" 
                                                Width="300px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            &nbsp;</td>
                                        <td class="style4">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            &nbsp;</td>
                                        <td class="style4">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td colspan="4">
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
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="cmdGuardar" runat="server" Text="GUARDAR" Width="156px" 
                        onclick="cmdGuardar_Click" />
                    &nbsp;<asp:Button ID="cmdReg" runat="server" Text="REGRESAR" Width="156px" 
                        onclick="cmdReg_Click" />
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

