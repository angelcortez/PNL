<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WDatoIncompetencia.aspx.cs" Inherits="AtencionTemprana.WDatoIncompetencia" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 105px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
<div id="main-wrapper">
       <script type="text/javascript">

           function revisarFechaRecuperado(sender, args) {
               if (sender._selectedDate > new Date()) {
                   alert("¡No se puede seleccionar un día posterior a la fecha actual!");
                   sender._selectedDate = new Date();
                   sender._textbox.set_Value(sender._selectedDate.format(sender._format))
               }
           }

           function revisarFechaDepositado(sender, args) {
               if (sender._selectedDate > new Date()) {
                   alert("¡No se puede seleccionar un día posterior a la fecha actual!");
                   sender._selectedDate = new Date();
                   sender._textbox.set_Value(sender._selectedDate.format(sender._format))
               }
           }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
        
<%--        <asp:PostBackTrigger ControlID="ddlDelito" />
        <asp:PostBackTrigger ControlID="cmdGu" />
        <asp:PostBackTrigger ControlID="cmdReg" />--%>

    </Triggers>
    <ContentTemplate>
    <asp:Label ID="IdCarpeta" runat="server" Visible="FALSE"></asp:Label>
    <asp:Label ID="IdMunicipio" runat="server" Visible="FALSE"></asp:Label>
    <asp:Label ID="lblArbol" runat="server" Visible="FALSE"></asp:Label>
<table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" Font-Size="Medium" 
                    class="color-fuente"></asp:Label>
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
         <asp:TextBox ID="txtFechaInicio1" runat="server" MaxLength="10" Width="200px"  Visible=False ></asp:TextBox>
    <h2> 
        <asp:Label ID="lblOperacion" runat="server" class="color-fuente" 
            ForeColor="Red"></asp:Label></h2>
     
     <br />

       <%--  <h2> <asp:Label ID="lblTitulo" runat="server" class="color-fuente" Text="DATOS DE LA INCOMPETENCIA"></asp:Label></h2>--%>
         <br />
     <table style="width: 100%;">
            <tr>
                <td>  <asp:Label ID="lblArea" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="AREA DE LA INCOMPETENCIA"></asp:Label>
                </td>
                <td>
                  <asp:Label ID="lblExpediente" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="EXPEDIENTE DE LA INCOMPETENCIA"></asp:Label>
                </td>
                <td>
                  <asp:Label ID="lblFechaInicio" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="FECHA DE INICIO DE LA INCOMPETENCIA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" class="chosen-select"
                         TabIndex="1" Width="250px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox runat="server"  TabIndex="2" Width="250px"  ID="txtExpediente" style="text-transform :uppercase" ></asp:TextBox>
<%--                    <asp:RequiredFieldValidator ID="validaAP" runat="server" ControlToValidate="txtExpediente"
                    Display="Dynamic" ErrorMessage="INGRESA CARPETA" Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                   <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" ErrorTooltipEnabled="True" AutoComplete="false" ClearTextOnInvalid="true"
                    Mask="99999\/9999" MaskType="None" MessageValidatorTip="true" TargetControlID="txtExpediente" />--%>
                </td>
                <td>
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="250px" TabIndex="3"
                       ></asp:TextBox>
                 <asp:CalendarExtender ID="txtFechaInicioCalendar" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaInicio" OnClientDateSelectionChanged="revisarFechaDepositado">
                    </asp:CalendarExtender>
                </td>

            </tr>
            <tr>
                <td align="center" colspan="3">
                                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                        <br />
                                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red" Visible="false"></asp:Label>
                        <br />
                    <asp:Button ID="cmdGu" runat="server"  Text="GUARDAR" 
                        Width="156px" TabIndex="58" Font-Bold="True" Height="40px"   
                        CssClass ="button" onclick="cmdGu_Click"/>
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server"  Text="REGRESAR" 
                        Width="156px" TabIndex="59" Font-Bold="True" Height="40px"   CssClass ="button" 
                                        Visible=false onclick="cmdReg_Click"/>
                     &nbsp;
                    <asp:Button ID="cmdContinuar" runat="server"  Text="CONTINUAR" 
                        Width="156px" TabIndex="59" Font-Bold="True" Height="40px"   CssClass ="button" 
                                        Visible=false onclick="cmdContinuar_Click"/>
                </td>
            
            </tr>
            
     </table>
     <br />
       <h3>        
       <asp:Label ID="lblDelitos" runat="server" class="color-fuente" Text="DELITOS" Visible=false></asp:Label>                             
       <asp:ImageButton ID="IBAgregarDelito" runat="server" Height="42px" 
               ImageUrl="~/img/Icono_Registro.png" Width="49px" visible="false" 
               onclick="IBAgregarDelito_Click" />         
       </h3>  
      <br />
      <table>
        <tr>
            <td><asp:Label ID="lblDelito" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="DELITO" Visible=false></asp:Label></td>
        </tr>
        <tr>
            <td>
            <asp:DropDownList ID="ddlDelito" runat="server" AutoPostBack="True" class="chosen-select"
                         TabIndex="1" Width="250px" Visible=false>
                    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                                                <asp:Label ID="lblEstatusDelito" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1Delito" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                        <br />
                                            <asp:Label ID="lblErrorDelito" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                        <br />
                  <asp:Button ID="Button1" runat="server"  Text="GUARDAR DELITO" 
                        Width="156px" TabIndex="58" Font-Bold="True" Height="40px"   
                        CssClass ="button" onclick="Button1_Click" />
            </td>
        </tr>
      </table>
      <br />

        <asp:GridView ID="GridDelito" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            DataSourceID="dsBuscaDelitoIncompetencia" Visible=true>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" Visible=false />
                <asp:BoundField DataField="IdCarpeta" HeaderText="IdCarpeta" 
                    SortExpression="IdCarpeta" Visible=false />
                <asp:BoundField DataField="IdMunicipio" HeaderText="IdMunicipio" 
                    SortExpression="IdMunicipio" Visible=false />
                <asp:BoundField DataField="IdDelito" HeaderText="IdDelito" 
                    SortExpression="IdDelito" Visible=false />
                <asp:BoundField DataField="DLTO" HeaderText="DELITO" SortExpression="DLTO" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    
  
    <br />
    <br />
                    <asp:SqlDataSource ID="dsBuscaDelitoIncompetencia" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="SP_BuscaIncompetenciaDelitos" 
           SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="IdCarpeta" Name="IdCarpeta" 
                                PropertyName="Text" Type="Int32" />
                            <asp:ControlParameter ControlID="IdMunicipio" Name="IdMunicipio" 
                                PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    
</div>

</asp:Content>

