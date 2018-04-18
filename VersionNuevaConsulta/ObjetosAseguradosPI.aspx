<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ObjetosAseguradosPI.aspx.cs" Inherits="AtencionTemprana.ObjetosAseguradosPI" %>

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
            display: none;
        }
        .margen
        {
            margin: 5px;
        }
        
        #myDIV
        {
            border: 1px solid black;
            margin-bottom: 10px;
        }
        
        #myDIVEHICULOS
        {
            border: 1px solid black;
            margin-bottom: 10px;
        }
        
        .style2
        {
            width: 335px;
        }
        
        .style3
        {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="main-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="cmdElaborarDocumento" />
                <asp:PostBackTrigger ControlID="cmdGuardar" />
            </Triggers>
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" Font-Size="Medium"></asp:Label>
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
                            <asp:Label ID="IdUsuario" runat="server" Visible="False"></asp:Label>
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
                            <asp:Label ID="lblArbol" runat="server" Visible="False">6</asp:Label>
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
                            <asp:Label ID="IdCarpeta" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="ID_ESTADO_NUC" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="IdUnidad" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="IdMunicipio" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="IdOrden" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="IdCustodiaObj" runat="server" Text="0" Visible="false"></asp:Label>
                            <asp:Label ID="IdCustodiaVeh" runat="server" Text="0" Visible="false"></asp:Label>
                            <asp:Label ID="IdInfo" runat="server" Text="0" Visible="false"></asp:Label>
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
                            <!--

                      <asp:ImageButton ID="ImageButton1" runat="server" Height="18px" 
                        ImageUrl="img/object.png" Width="18px" onclick="ImageButton1_Click" />
                     <asp:Label ID="Label5" Text="ELIMINAR OBJETOS" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"  class="margen"></asp:Label>    
                              
                     <asp:ImageButton ID="ImageButton2" runat="server" Height="18px" 
                        ImageUrl="img/object.png" Width="18px" onclick="ImageButton2_Click"  />
                     <asp:Label ID="Label21" Text="ELIMINAR VEHICULOS" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="#666666" style="text-transform :uppercase"></asp:Label>    
                                    
                      -->
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;" runat="server" id="tbl_informe">
                    <tr>
                        <td>
                            <br />
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="LUGAR DEL ASEGURAMIENTO:" Font-Bold="True"
                                Font-Size="Small" ForeColor="Black"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtLugarAseguramiento" runat="server" Width="338px" MaxLength="490"
                                Style="text-transform: uppercase"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>OBJETOS:</legend>
                                <table style="width: 100%;">
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
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CAUSA DE ASEGURAMIENTO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEspecificar1" runat="server" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black" Text="ESPECIFICAR"></asp:Label>
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
                                            <asp:DropDownList ID="ddlCausaObj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCausaObj_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEspecificarObj" runat="server" MaxLength="200"></asp:TextBox>
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
                                            <asp:Label ID="Label352" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CANTIDAD:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label355" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="TIPO DE OBJETO:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label356" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="DESCRIPCIÓN:"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCantidad" runat="server" MaxLength="3" Width="104px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="240" Width="134px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDescObj" runat="server" MaxLength="500" Width="306px"></asp:TextBox>
                                        </td>
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
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnAgregarObj" runat="server" OnClick="btnAgregarObj_Click1" Text="AGREGAR" />
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
                                            <asp:Label ID="Label343" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="OBJETOS ASEGURADOS:"></asp:Label>
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
                                        <td colspan="4">
                                            <asp:GridView ID="gvConsultarObjetos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="4" DataSourceID="dsVerObjetos" ForeColor="Black" GridLines="Vertical"
                                                Width="928px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="ID_OBJETO" HeaderText="ID_OBJETO" SortExpression="ID_OBJETO"
                                                        Visible="True" InsertVisible="False" ReadOnly="True">
                                                        <ItemStyle CssClass="hidden" />
                                                        <HeaderStyle CssClass="hidden" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
                                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" SortExpression="DESCRIPCION" />
                                                    <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" SortExpression="CANTIDAD" />
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <RowStyle BackColor="#CCFFCC" HorizontalAlign="Center" />
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
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="SE PONEN BAJO CUSTODIA DE:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label363" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="SE PONEN BAJO CUSTODIA EN:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label362" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CARGO CUSTODIO:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label361" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="IDENTIFICACÓN:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            <asp:TextBox ID="txtNombreCustodioObj" runat="server" MaxLength="250" Width="181px"></asp:TextBox>
                                        </td>
                                        <td class="style3">
                                            <asp:TextBox ID="txtLugarCustodiaObj" runat="server" MaxLength="250" Width="181px"></asp:TextBox>
                                        </td>
                                        <td class="style3">
                                            <asp:TextBox ID="txtCargoObj" runat="server" MaxLength="78" Width="181px"></asp:TextBox>
                                        </td>
                                        <td class="style3">
                                            <asp:TextBox ID="txtIdentificacionObj" runat="server" MaxLength="50" Width="181px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            <asp:Label ID="Label364" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="SE ASEGURARON A:"></asp:Label>
                                        </td>
                                        <td class="style3">
                                            <asp:Label ID="Label370" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CON DOMICILIO EN:"></asp:Label>
                                        </td>
                                        <td class="style3">
                                            <asp:Label ID="Label369" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="TELEFONO:"></asp:Label>
                                        </td>
                                        <td class="style3">
                                            <asp:Label ID="Label368" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="RELACION O PARENTESCO EN EL CASO:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            <asp:TextBox ID="txtNombreDueñoObj" runat="server" MaxLength="250" Width="181px"></asp:TextBox>
                                        </td>
                                        <td class="style3">
                                            <asp:TextBox ID="txtDomicilioDueñoObj" runat="server" MaxLength="250" Width="181px"></asp:TextBox>
                                        </td>
                                        <td class="style3">
                                            <asp:TextBox ID="txtTelefonoDueñoObj" runat="server" MaxLength="15" Width="181px"></asp:TextBox>
                                        </td>
                                        <td class="style3">
                                            <asp:TextBox ID="txtRelacionCasoObj" runat="server" MaxLength="50" Width="181px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="FECHA ENTREGA:"></asp:Label>
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                            <asp:TextBox ID="txtFechaObj" runat="server" MaxLength="15" Width="181px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFechaInicioOrden_CalendarExtender" runat="server" Enabled="True"
                                                Format="dd/MM/yyyy" TargetControlID="txtFechaObj">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td class="style3">
                                            <asp:Button ID="btnGuardarObj" runat="server" Height="31px" OnClick="btnGuardarObj_Click"
                                                Text="GUARDAR" Width="137px" />
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                        <td class="style3">
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:SqlDataSource ID="dsVerObjetos" runat="server" ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>"
                                                SelectCommand="SeleccionarObjetosAsegurados_PI" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="IdCarpeta" Name="ID_CARPETA" PropertyName="Text"
                                                        Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            <br />
                            <br />
                            <fieldset>
                                <legend>VEHICULOS:</legend>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="OBSERVACIONES"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    
                                    
                                    
                                   
                                   
                                   
                                   
                                    
                                   
                                   
                                    
                                    
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;</td>
                                        
                                       
                                        
                                       
                                        
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
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="SE PONEN BAJO CUSTODIA DE:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="SE PONEN BAJO CUSTODIA EN:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="CARGO CUSTODIO:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label344" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="IDENTIFICACÓN:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtNombreCustodioVeh" runat="server" MaxLength="250" 
                                                    Width="181px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLugarCustodiaVeh" runat="server" MaxLength="250" 
                                                    Width="181px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCargoVeh" runat="server" MaxLength="70" Width="181px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIdentificacionVeh" runat="server" MaxLength="40" 
                                                    Width="181px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label345" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="SE ASEGURARON A:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label349" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="CON DOMICILIO EN:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label350" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="TELEFONO:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label351" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="RELACION O PARENTESCO EN EL CASO:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtNombreDueñoVeh" runat="server" MaxLength="250" 
                                                    Width="181px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDomicilioDueñoVeh" runat="server" MaxLength="250" 
                                                    Width="181px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTelefonoDueñoVeh" runat="server" MaxLength="15" 
                                                    Width="181px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRelacionCasoVeh" runat="server" MaxLength="40" 
                                                    Width="181px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Black" Text="FECHA ENTREGA:"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtFechaVeh" runat="server" MaxLength="15" Width="181px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
                                                    Format="dd/MM/yyyy" TargetControlID="txtFechaVeh">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnGuardarVeh" runat="server" Height="25px" 
                                                    OnClick="btnGuardarVeh_Click" Text="GUARDAR" Width="144px" />
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:SqlDataSource ID="dsVerVehiculos" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                                                    SelectCommand="SeleccionarVehiculosAsegurados_PI" 
                                                    SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="IdCarpeta" Name="ID_CARPETA" 
                                                            PropertyName="Text" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </tr>
                                  </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;" runat="server" id="tbl_elaborar">
                    <tr>
                        <td colspan="5" class="style2">
                            <br />
                            <br />
                            <asp:Button ID="cmdElaborarDocumento" runat="server" Text="ELABORAR DOCUMENTO" OnClick="cmdElaborarDocumento_Click" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="Label332" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                Text="SELECCIONE DOCUMENTO PDF"></asp:Label>
                            <br />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Label ID="Label333" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="cmdGuardar" runat="server" TabIndex="32" Text="GUARDAR DOCUMENTO"
                                Width="256px" Font-Bold="True" OnClick="cmdGuardar_Click" />
                            <br />
                            <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" OnClick="cmdReg_Click"
                                TabIndex="32" Text="REGRESAR" Width="156px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
