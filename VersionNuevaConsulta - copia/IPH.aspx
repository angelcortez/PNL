<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IPH.aspx.cs" Inherits="AtencionTemprana.IPH" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content3" runat="server" 
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
    </table>  





    <table style="width: 100%;">
            <tr>
                <td colspan="3" align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblIdUnidad" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblIdCarpeta" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="IdMunicipio" runat="server" Visible="False"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="BUSCAR"></asp:Label>
                    <asp:DropDownList ID="ddlBuscarIPH" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlBuscarIPH_SelectedIndexChanged">
                        <asp:ListItem Value="0">POR</asp:ListItem>
                        <asp:ListItem Value="1">IPH</asp:ListItem>
                        <asp:ListItem Value="2">FOLIO</asp:ListItem>
                        <asp:ListItem Value="3">DETENIDO</asp:ListItem>
                        <asp:ListItem Value="4">HUELLA</asp:ListItem>
                        <asp:ListItem Value="5">IMAGEN</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblIPH" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="IPH" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtIPHBusqIPH" runat="server" MaxLength="10" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtIPHBusqIPH_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtIPHBusqIPH">
                    </asp:CalendarExtender>
                    &nbsp;<asp:Label ID="lblFolio" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FOLIO" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtFolioBusqIPH" runat="server" MaxLength="10" 
                        Visible="False" Width="150px"></asp:TextBox>
&nbsp;
                    <asp:Label ID="lblNombre" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="NOMBRE" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtNombreBusqIPH" runat="server" Visible="False" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblPaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="PATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPaternoBusqIPH" runat="server" Visible="False" 
                        Width="150px"></asp:TextBox>
                    <asp:Label ID="lblMaterno" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="MATERNO" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMaternoBusqIPH" runat="server" Visible="False" 
                        Width="150px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;<br />
                    <br />
                    <asp:Label ID="lblHuellaIPH" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="HUELLA"></asp:Label>
                    <asp:ImageButton ID="imgBtnHuella" runat="server" Height="150px" 
                        Width="150px" />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="lblImagenIPH" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="IMAGEN"></asp:Label>
                    <asp:FileUpload ID="fuImagenIPH" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnAceptarIPH" runat="server" onclick="btnAceptarIPH_Click" 
                        Text="ACEPTAR" Width="156px" Height="30px" />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvIPH" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="927px" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False"
                        DataSourceID="dsconsultaIPH" 
                        
                       
                        >

                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID_CARPETA" HeaderText="ID_CARPETA" 
                                SortExpression="ID_CARPETA" />
                            <asp:BoundField DataField="IPH" HeaderText="IPH" SortExpression="IPH" />
                            <asp:BoundField DataField="NUMERO_FOLIO" HeaderText="NUMERO_FOLIO" 
                                SortExpression="NUMERO_FOLIO" />
                            <asp:BoundField DataField="NUMERO_OFICIO" HeaderText="NUMERO_OFICIO" 
                                SortExpression="NUMERO_OFICIO" />
                            <asp:BoundField DataField="FECHA_INFORME" HeaderText="FECHA_INFORME" 
                                ReadOnly="True" SortExpression="FECHA_INFORME" />
                            <asp:BoundField DataField="PARTICIPACION" HeaderText="PARTICIPACION" 
                                SortExpression="PARTICIPACION" />
                            <asp:CheckBoxField DataField="OPERATIVO" HeaderText="OPERATIVO" 
                                SortExpression="OPERATIVO" />
                            <asp:BoundField DataField="COMANDANTE_DE_OPERATIVO" 
                                HeaderText="COMANDANTE_DE_OPERATIVO" SortExpression="COMANDANTE_DE_OPERATIVO" />
                            <asp:BoundField DataField="DETENIDO" HeaderText="DETENIDO" ReadOnly="True" 
                                SortExpression="DETENIDO" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                                                            <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                                                        HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <RowStyle BackColor="#CCFFCC" 
                            HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="dsconsultaIPH" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="consultaIPH" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" DefaultValue="" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarIPHiph" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarIPHiph" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Name="IDIPH" Type="Int32" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>

                    <asp:SqlDataSource ID="dsBuscarIPHFolio" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarIPHFolio" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Name="FOLIO" Type="Int32" />
                            <asp:Parameter Name="IdMunicipio" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsbuscarIPHDetenido" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarIPHDetenido" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtNombreBusqIPH" DefaultValue=" " Name="Nombre" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtPaternoBusqIPH" DefaultValue=" " Name="Paterno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtMaternoBusqIPH" DefaultValue=" " Name="Materno" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarIPHHuella" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarIPHHuella" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Name="HUELLA" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="dsBuscarIPHImagen" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="buscarIPHImagen" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Name="IMAGEN" Type="String" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int16" />
                            <asp:ControlParameter ControlID="lblIdUnidad" Name="IdUnidad" 
                                PropertyName="Text" Type="Int16" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
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
                    &nbsp;
                </td>
            </tr>
        </table>





        </ContentTemplate>
  </asp:UpdatePanel>
    
   
</div>
</asp:Content>



