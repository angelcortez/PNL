<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PNLPersonasNSJP.aspx.cs" Inherits="AtencionTemprana.PNLPersonasNSJP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" language="JavaScript">
        //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 13; /*BLOQUEAR ENTER*/ }
        document.onkeydown = function (evt1) { return (evt1 ? evt1.which : event.keyCode) != 13; } /*BLOQUEAR BACKSPACE*/
        //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 32; } /*BLOQUEAR BARRA ESPACIDORA*/
    </script>
    <div id="main-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="gvNuc" />--%>
            </Triggers>
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" class="color-fuente"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFecha" runat="server" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                            <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="LblOfendido2" runat="server" Font-Bold="True" Font-Size="Medium" class="color-fuente">INGRESE DATOS CORRESPONDIENTES</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="lblNombre3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="NOMBRE"></asp:Label>
                            <asp:TextBox ID="txtNombre3" runat="server" Style="text-transform: uppercase" Width="150px"></asp:TextBox>
                            <asp:Label ID="lblPaterno3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="PATERNO"></asp:Label>
                            <asp:TextBox ID="txtPaterno3" runat="server" Style="text-transform: uppercase" Width="150px"></asp:TextBox>
                            <asp:Label ID="lblMaterno3" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="MATERNO"></asp:Label>
                            <asp:TextBox ID="txtMaterno3" runat="server" Style="text-transform: uppercase" Width="150px"></asp:TextBox>
                            <asp:Button ID="BtnBuscar1" runat="server" OnClick="BtnBuscar1_Click" Text="OK" class="button" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;&nbsp;
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Visible="False" CellPadding="4" DataSourceID="dsConsultaPersonasTotal" ForeColor="#333333"
                                GridLines="None" Style="text-transform: uppercase" Width="930px" 
                                DataKeyNames="ID_CARPETA">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                   <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                             <a href='NUC_PNL.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUC=<%#Eval("ID_ESTADO_NUC")%>'>
                                 <asp:Image ID="Image1" runat="server" Height="40px" ImageUrl="img/view-tree.png" /></a>
                               <%--<a href='NUC.aspx?ID_CARPETA=<%#Eval("ID_CARPETA")%>&amp;ID_ESTADO_NUC=<%#Eval("ID_ESTADO_NUC")%>'>
                                 <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" /></a>--%>
                            </ItemTemplate>
                          </asp:TemplateField>
                                    <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                        SortExpression="ID_CARPETA" ReadOnly="True" Visible="False" />
                                    <asp:BoundField DataField="ID_ESTADO_NUC" HeaderText="ID_ESTADO_NUC" 
                                        SortExpression="ID_ESTADO_NUC" Visible="False" />
                                    <asp:BoundField DataField="ID_UNDD" HeaderText="ID_UNDD" 
                                        SortExpression="ID_UNDD" Visible="False" />
                                    <asp:BoundField DataField="NUC" HeaderText="NUC" ReadOnly="True" 
                                        SortExpression="NUC" />
                                    <asp:BoundField DataField="ESTADO_CARPETA" HeaderText="ESTADO CARPETA" 
                                        SortExpression="ESTADO_CARPETA" ReadOnly="True" />
                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" 
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="ACTR_TPO" HeaderText="TIPO ACTOR" 
                                        SortExpression="ACTR_TPO" />
                                    <asp:BoundField DataField="ALIAS" HeaderText="ALIAS" SortExpression="ALIAS" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    &nbsp;
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:SqlDataSource ID="dsConsultaPersonasTotal" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString %>"
                                SelectCommand="PNL_Localizado_Buscar_Por_Ofendido" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="41" Name="IdMunicipio" Type="Int16" />
                                    <asp:Parameter DefaultValue="80" Name="IdUnidad" Type="Int16" />
                                    <asp:ControlParameter ControlID="txtNombre3" DefaultValue=" " Name="Nombre" PropertyName="Text"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtPaterno3" Name="Paterno" PropertyName="Text"
                                        Type="String" DefaultValue=" " />
                                    <asp:ControlParameter ControlID="txtMaterno3" Name="Materno" PropertyName="Text"
                                        Type="String" DefaultValue=" " />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="Black" Text="ESTADOS DE CARPETA NUC"></asp:Label>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" BackColor="Red" />
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" Text="TRAMITE"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button5" runat="server" BackColor="Blue" />
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" Text="JUDICIALIZADA"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button3" runat="server" BackColor="Black" />
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" Text="ARCHIVO TEMPORAL"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" BackColor="#802A2A" />
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" Text="NO EJERCICIO"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button4" runat="server" BackColor="#00CC00" />
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" Text="CRITERIO DE OPORTUNIDAD"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
