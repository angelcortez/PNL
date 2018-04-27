<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PNLUnidades.aspx.cs" Inherits="AtencionTemprana.PNLUnidades" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 371px;
        }
        .style4
        {
            width: 106px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main-wrapper">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

     



    
    <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td class="style4">
                    <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" class="color-fuente" Text="Unidades PNL"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style4">
                    &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </tr>
            <tr>
                <td class="style4">
                    <a href = "UnidadRAC.aspx"><img src = "img/view-tree.png" height = "40px"> </a>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td class="style4">
                    <asp:Label ID="Label1" runat="server"  Font-Size="Medium"  Text="VICTORIA"></asp:Label>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Image ID="Image2" runat="server" Height="40px" ImageUrl="img/view-tree.png" />
                    </td>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server"  Font-Size="Medium"  Text="TAMPICO"></asp:Label>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Image ID="Image3" runat="server" Height="40px" ImageUrl="img/view-tree.png" />
                    </td>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server"  Font-Size="Medium"  Text="REYNOSA"></asp:Label>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Image ID="Image4" runat="server" Height="40px" ImageUrl="img/view-tree.png" />
                    </td>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server"  Font-Size="Medium"  Text="MATAMORS"></asp:Label>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Image ID="Image5" runat="server" Height="40px" ImageUrl="img/view-tree.png" />
                    </td>
                <td class=style4>
                    <asp:Label ID="Label3" runat="server"  Font-Size="Medium"  Text="NUEVO LAREDO"></asp:Label>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
                <tr>
                <td align="right" class="style4">
                    <asp:Label ID="lblFecha" runat="server"  ForeColor="Black"></asp:Label>
                </td>
                    <td align="right" class="style3">
                        &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                </tr>
          </table>
 </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>

