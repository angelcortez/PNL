<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PNLUnidades.aspx.cs" Inherits="AtencionTemprana.PNLUnidades" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main-wrapper">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">     
     <Triggers>
    <asp:PostBackTrigger ControlID="GridUnidades" />
    </Triggers>
    <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" class="color-fuente" Text="Unidades"></asp:Label>
                </td>
                </tr>
                <tr>
                <td>
                    <asp:GridView ID="GridUnidades" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="None" Width="1050px" 
                        AutoGenerateColumns="False" Visible="false"                        
                        AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="idUnidad , municipio"
                        OnSelectedIndexChanged="GridUnidades_SelectedIndexChanged"                        
                        AutoGenerateSelectButton="True" >                        
                        
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                           <asp:TemplateField HeaderText=" ">
                                                    <ItemTemplate>
                                                    <%-- <a href='RAC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_RAC=<%#Eval("ID_ESTADO_RAC")%>'>        --%>        
                                                    <!--<a href='UnidadRAC.aspx'>-->
                                                    <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/view-tree.png"/>
                                                    <!--</a>-->
                                                    </ItemTemplate>                                                                     
                           </asp:TemplateField>

                           <asp:BoundField DataField="idUnidad" HeaderText="idUnidad" 
                                SortExpression="idUnidad" Visible="TRUE" />
                            <asp:BoundField DataField="municipio" HeaderText="MUNICIPIO" ReadOnly="True" 
                                SortExpression="idMunicipio" />
                            <asp:BoundField DataField="ip" HeaderText="DIRECCIÓN IP" 
                                SortExpression="ip" ReadOnly="True" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#507CD1" 
                            Font-Bold="True" ForeColor="White" 
                                                        HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#2461BF" 
                            ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#EFF3FB" 
                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" 
                            Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                   
                </td>
                </tr>
                <tr>
                <td>
                    <asp:SqlDataSource ID="dsCargarUnidades" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>" 
                        SelectCommand="spPNLConsultarServidoresUnidades" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                </td>
                </tr>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                </td>
            </tr>
          </table>
 </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>

