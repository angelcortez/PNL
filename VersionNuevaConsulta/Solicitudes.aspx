<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.cs" Inherits="AtencionTemprana.Solicitudes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 19px;
            text-align: left;
        }
        .style3
        {
            color: #000000;
        }
        .style4
        {
            height: 17px;
            text-align: center;
        }
        .style5
        {
            width: 156px;
        }
        .style6
        {
            color: #000000;
            width: 156px;
        }
        .style7
        {
            height: 19px;
            text-align: left;
            width: 156px;
        }
        .style8
        {
            width: 453px;
        }
        .style9
        {
            width: 156px;
            height: 25px;
        }
        .style10
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
    <asp:PostBackTrigger ControlID="btnGuardar" />
    </Triggers>
    <ContentTemplate>
    
    <table style="width: 100%;">
        <tr>
            <td class="style8">
                
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
            <td class="style8">
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="Black" 
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
            <td class="style8">
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
            <td class="style8">
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
        <asp:Label ID="lblOperacion" runat="server" 
            ForeColor="#006600"></asp:Label></h2>
        <table style="width: 100%;">
        <tr>
                <td class="style5">
                    <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Id_Solicitud" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    <b>NUC</td>
                <td class="style3">
                    <strong>TIPO DE SOLICITUD</strong></td>
                <td class="style3">
                    <strong>TIPO DE AUDIENCIA</b></strong></td>
                <td class="style3">
                    <strong>DOCUMENTO</strong></td>
            </tr>
            <tr>
                <td class="style9">
                   
                    <asp:Label ID="lblNuc" runat="server" style="color: #000000"></asp:Label>
                   
                </td>
                <td class="style10">
                    <asp:DropDownList ID="ddlTipoSolicitud" runat="server" Height="19px" 
                        Width="130px">
                        <asp:ListItem Value="1">NORMAL</asp:ListItem>
                        <asp:ListItem Value="2">URGENTE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    <asp:DropDownList ID="ddlTipoAudiencia" runat="server" 
                        DataSourceID="dsTipoSolicitudAudiencia" 
                        DataTextField="Tipo_Solicitud_Audiencia" 
                        DataValueField="Id_Tipo_Solicitud_Audiencia" Width="250px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="dsTipoSolicitudAudiencia" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="cargaTipoSolicitudAudiencia" 
                        SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                </td>
                <td class="style10">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    </td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    </td>
            </tr>
            <tr>
                <td colspan="4" class="style4">

                    <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                        Text="GUARDAR" Font-Bold="True" Height="40px" Width="156px" />

                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdReg_Click1" Text="REGRESAR" Width="156px" />

                    </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">

                    
                    
                       &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    </td>
                <td class="style2">
                    </td>
                <td class="style2">
                    </td>
                <td class="style2">
                    </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
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
                <td class="style5">
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
