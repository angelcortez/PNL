<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarDocs.aspx.cs" Inherits="AtencionTemprana.GenerarDocs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">
            function mostrarFichero(destino) {
                window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
                document.forms(0).submit();
            }
    </script>
<div id="main-wrapper">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

      <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="LBLUSUARIO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
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
                
                &nbsp;</td>
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
                
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
     
      
    </table> 
<h2><asp:Label ID="Label1" runat="server" ForeColor="#006600"></asp:Label>
    
    </h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
  
            <asp:TextBox ID="txtPlantilla" runat="server" 
                ontextchanged="txtPlantilla_TextChanged" AutoPostBack="True"></asp:TextBox>
            <asp:Button ID="txtBuscar" runat="server" onclick="txtBuscar_Click" Text="Buscar" 
                PostBackUrl="~/GenerarDocs.aspx" />
            <asp:TextBox ID="txtDenunciante" runat="server" Width="300px"></asp:TextBox>
            <asp:GridView ID="gvDocs" runat="server" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="dsConsulta" 
                ForeColor="Black" GridLines="Vertical"  Width="927px" 
                onrowcommand="gvDocs_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID_PLANTILLA" HeaderText="ID_PLANTILLA" 
                        SortExpression="ID_PLANTILLA" />
                    <asp:BoundField DataField="TIPO_PLANTILLA" HeaderText="TIPO_PLANTILLA" 
                        SortExpression="TIPO_PLANTILLA" />
                    <asp:BoundField DataField="NOMBRE_PLANTILLA" HeaderText="NOMBRE_PLANTILLA" 
                        SortExpression="NOMBRE_PLANTILLA" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnDescargar" runat="server" Height="31px" 
                                ImageUrl="~/img/DESCARGAR.png"  
                                CommandArgument='<%#Eval("ID_PLANTILLA")%>' PostBackUrl="~/GenerarDocs.aspx" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Center" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#CCFFCC" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <asp:SqlDataSource ID="dsConsulta" runat="server" 
                ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                SelectCommand="consultaCAT_PLANTILLAS" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtPlantilla" Name="nombre" 
                        PropertyName="Text" Type="String" DefaultValue="" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Guardar Documento Generado" />
        </ContentTemplate>
        <Triggers>  
        <asp:AsyncPostBackTrigger ControlID="txtPlantilla" EventName="TextChanged" />  
        </Triggers>
    </asp:UpdatePanel>
</div>
</asp:Content>
