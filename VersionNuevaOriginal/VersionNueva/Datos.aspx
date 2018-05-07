<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="AtencionTemprana.Datos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="GMaps" namespace="Subgurim.Controles" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 537px;
        }
        .style4
        {
            width: 536px;
        }
        .style5
        {
            width: 179px;
        }
        .style6
        {
            height: 19px;
        }
        .style7
        {
            height: 15px;
        }
        .style9
        {
            height: 23px;
        }
        .style11
        {
            width: 126px;
        }
        .style13
        {
            width: 163px;
        }
        .style15
        {
            width: 178px;
        }
        .style16
        {
            width: 182px;
        }
        .style17
        {
            width: 262px;
        }
        .style18
        {
            width: 267px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <%-- <asp:ModalPopupExtender ID="Panel2_ModalPopupExtender" runat="server" PopupControlID="Panel2"
                        DynamicServicePath="" Enabled="True" TargetControlID="Label40" PopupDragHandleControlID="PoppupHeader" Drag="true" BackgroundCssClass="ModalPopupBG">
                    </asp:ModalPopupExtender>--%>

   <script type="text/javascript" language="JavaScript">
       //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 13; /*BLOQUEAR ENTER*/ }
       document.onkeydown = function (evt1) { return (evt1 ? evt1.which : event.keyCode) != 13; } /*BLOQUEAR BACKSPACE*/
       //        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 32; } /*BLOQUEAR BARRA ESPACIDORA*/
   </script>
   
        
<div id="main-wrapper">
 
 <script type="text/javascript" >
     //    function txNombre() {
     //        if (((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122)) && (event.keyCode = 209 || event.keyCode = 241))
     //            event.returnValue = false;
     //    }

     function soloLetras(e) {
         key = e.keyCode || e.which;
         tecla = String.fromCharCode(key).toString();
         letras = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ"; //Se define todo el abecedario que se quiere que se muestre.
         especiales = [8, 37, 39, 46, 6, 32]; //Es la validación del KeyCodes, que teclas recibe el campo de texto.

         tecla_especial = false
         for (var i in especiales) {
             if (key == especiales[i]) {
                 tecla_especial = true;
                 break;
             }
         }

         if (letras.indexOf(tecla) == -1 && !tecla_especial) {
             alert('Tecla no aceptada');
             return false;
         }
     }

   </script> 
 

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 
   <asp:UpdatePanel ID="UpdatePanel5" runat="server">
     <Triggers>
        <asp:PostBackTrigger ControlID="cmdAlias" />
        <asp:PostBackTrigger ControlID="ddlPais" />
        <asp:PostBackTrigger ControlID="ddlEstado" />
        <asp:PostBackTrigger ControlID="ddlMunicipio" />

        <asp:PostBackTrigger ControlID="ddlPaisDom" />
        <asp:PostBackTrigger ControlID="ddlEstadoDom" />
        <asp:PostBackTrigger ControlID="ddlMunicipioDom" />
        <asp:PostBackTrigger ControlID="ddlLocalidadDom" />
        <asp:PostBackTrigger ControlID="ddlColonia" />

        <asp:PostBackTrigger ControlID="IBDetenidoSi" />
        <asp:PostBackTrigger ControlID="IBDetenidoNo" />
        <asp:PostBackTrigger ControlID="ddlMunicipioLH" />
        <asp:PostBackTrigger ControlID="ddlLocalidadLH" />

        <asp:PostBackTrigger ControlID="cmdMapa" />
        <asp:PostBackTrigger ControlID="OptProcedimientoDetencion" />
        <asp:PostBackTrigger ControlID="rbLibertadInvestigacion" />
        <asp:PostBackTrigger ControlID="cmdMedio" />

        <asp:PostBackTrigger ControlID="ImgSi1" />
        <asp:PostBackTrigger ControlID="ImgNo1" />
        <asp:PostBackTrigger ControlID="cmdGu" />
        <asp:PostBackTrigger ControlID="cmdReg" />
      

    </Triggers>
    <ContentTemplate>
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
            <td class="style6">
                <asp:Label ID="PUESTO" runat="server" Font-Bold="True" ForeColor="#666666" 
                    style="text-transform :uppercase"></asp:Label>
            </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
            <td align="right" class="style6">
                </td>
        </tr>
     
      
        <tr>
            <td class="style6">
                <asp:Label ID="lblArbol" runat="server" Visible="false"></asp:Label>
                </td>
            <td class="style6">
                </td>
            <td class="style6">
                </td>
            <td align="right" class="style6">
                </td>
        </tr>
     
      
    </table>  

    <h2> 
        <asp:Label ID="lblOperacion" runat="server"  class="color-fuente"></asp:Label></h2>

        <table style="width: 100%;">
         <tr>
                <td class="style7">
                    <asp:Label ID="ID_PERSONA" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                <td class="style7">
                    
                    <asp:Label ID="ID_PERSONA_CARPETA" runat="server" ForeColor="Red" 
                        Visible="False"></asp:Label>
                    
                </td>
                <td class="style7">
                    
                    <asp:Label ID="ID_DOMICILIO" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="ID_CARPETA" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="ID_TIPO_ACTOR" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="ID_LUGAR_DETENCION" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="IdDetencion" runat="server" Font-Bold="True" ForeColor="#666666" Style="text-transform: uppercase"
                        Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel3" runat="server" GroupingText="NOMBRE" Font-Bold="True" 
                        Font-Size="Medium"  >
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="NOMBRE"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="PATERNO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="MATERNO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" MaxLength="30" TabIndex="1" Width="250px" 
                                        ID="txtNombre" style="text-transform :uppercase" onkeypress="return soloLetras(event);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" 
                                        ControlToValidate="txtNombre" ErrorMessage="INGRESA NOMBRE" Display="Dynamic" 
                                        Font-Bold="True" Font-Size="Small" ID="RequiredFieldValidator1">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-zA-ZñÑ ]*$" Font-Size="Small"  ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" MaxLength="30" TabIndex="2" Width="250px" 
                                        ID="txtPaterno" style="text-transform :uppercase" onkeypress="return soloLetras(event);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ForeColor="Red" 
                                        ControlToValidate="txtPaterno" ErrorMessage="INGRESA PATERNO" Display="Dynamic" 
                                        Font-Bold="True" Font-Size="Small" ID="RequiredFieldValidator2">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPaterno"
                ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-zA-ZñÑ ]*$" Font-Size="Small"  ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" MaxLength="30" TabIndex="3" Width="250px" 
                                        ID="txtMaterno" style="text-transform :uppercase" onkeypress="return soloLetras(event);"></asp:TextBox>
                                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMaterno"
                ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-zA-ZñÑ ]*$" Font-Size="Small"  ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblIdTipoActor" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel4" runat="server" GroupingText="ALIAS" Font-Bold="True" 
                        Font-Size="Medium" >
                        <table style="width:100%;">
                            <tr>
                                <td class="style5">
                                    <asp:Label runat="server" Text="AGREGAR" Font-Bold="True" 
                                        Font-Size="Small"  class="color-fuente" ID="Label32"></asp:Label>
                                    <asp:Button ID="cmdAlias" runat="server" OnClick="cmdAlias_Click" Text=" + " 
                                        Width="50px" class="button" />
                                </td>
                                <td class="style3">
                                    &nbsp;</td>
                                <td class="style4">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView runat="server" AutoGenerateColumns="False" CellPadding="4" 
                                        GridLines="None" DataSourceID="dsAlias" ForeColor="#333333" 
                                        Width="470px" ID="gvAlias">
                                        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="EDITAR">
                                                <ItemTemplate>
                                                    <a href='Alias.aspx?ID_PERSONA=<%#Eval("ID_PERSONA")%>&amp;&amp;op=Modificar&amp;ID_ALIAS=<%#Eval("ID_ALIAS")%>&amp;'>
                                                    <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" 
                                 Width="18px" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID_ALIAS" HeaderText="ID_ALIAS" 
                                                SortExpression="ID_ALIAS" Visible="False"></asp:BoundField>
                                            <asp:BoundField DataField="ALIAS" HeaderText="ALIAS" SortExpression="ALIAS">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" 
                                                SortExpression="ID_PERSONA" Visible="False"></asp:BoundField>
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                        <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" Font-Bold="True" 
                                            ForeColor="White"></HeaderStyle>
                                        <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White">
                                        </PagerStyle>
                                        <RowStyle HorizontalAlign="Left" BackColor="#EFF3FB"></RowStyle>
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333">
                                        </SelectedRowStyle>
                                        <SortedAscendingCellStyle BackColor="#F5F7FB">
                                        </SortedAscendingCellStyle>
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1">
                                        </SortedAscendingHeaderStyle>
                                        <SortedDescendingCellStyle BackColor="#E9EBEF">
                                        </SortedDescendingCellStyle>
                                        <SortedDescendingHeaderStyle BackColor="#4870BE">
                                        </SortedDescendingHeaderStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    <asp:SqlDataSource runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                                        SelectCommand="consultaAlias" SelectCommandType="StoredProcedure" ID="dsAlias">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ID_PERSONA" PropertyName="Text" 
                                                Name="IdPersona" Type="Int32"></asp:ControlParameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td class="style3">
                                    &nbsp;</td>
                                <td class="style4">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    
                     
                  
                    <asp:Panel ID="Panel5" runat="server" GroupingText="ORIGINARIO" 
                        Font-Bold="True" Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="NACIONALIDAD"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="PAÍS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="ESTADO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                                    Font-Size="Small" ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList  ID="ddlNacionalidad" runat="server" Width="200px" class="chosen-select"
                                TabIndex="4">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="ddlNacionalidad" Display="Dynamic" 
                                ErrorMessage="INGRESA NACIONALIDAD" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPais" runat="server" Width="200px" AutoPostBack="True" class="chosen-select"
                                onselectedindexchanged="ddlPais_SelectedIndexChanged" TabIndex="5">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="ddlPais" Display="Dynamic" ErrorMessage="INGRESA PAIS" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstado" runat="server" Width="200px" class="chosen-select"
                                    AutoPostBack="True" 
                                    onselectedindexchanged="ddlEstado_SelectedIndexChanged" TabIndex="6">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="ddlEstado" Display="Dynamic" ErrorMessage="INGRESA ESTADO" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList  ID="ddlMunicipio" runat="server" Width="200px" TabIndex="7" class="chosen-select" >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="ddlMunicipio" Display="Dynamic" 
                                    ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                     
                  
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
                <td colspan="4">
                    &nbsp;<asp:Panel ID="Panel6" runat="server" 
                        GroupingText="DOMICILIO PARTICULAR ACTUAL" Font-Bold="True" 
                        Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="PAÍS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ESTADO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MUNICIPIO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LOCALIDAD"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlPaisDom" runat="server" Width="200px" class="chosen-select"
                                    AutoPostBack="True" 
                                    onselectedindexchanged="ddlPaisDom_SelectedIndexChanged" TabIndex="8">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="ddlPaisDom" Display="Dynamic" ErrorMessage="INGRESA PAIS" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstadoDom" runat="server" Width="200px" class="chosen-select"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlEstadoDom_SelectedIndexChanged" TabIndex="9">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                        ControlToValidate="ddlEstadoDom" ErrorMessage="INGRESA ESTADO" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipioDom" runat="server" Width="200px" class="chosen-select"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlMunicipioDom_SelectedIndexChanged" 
                                        TabIndex="10">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                        ControlToValidate="ddlMunicipioDom" Display="Dynamic" 
                                        ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadDom" runat="server" Width="200px" class="chosen-select"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlLocalidadDom_SelectedIndexChanged" 
                                        TabIndex="11">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                        ControlToValidate="ddlLocalidadDom" Display="Dynamic" 
                                        ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="COLONIA"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlColonia" runat="server" Width="470px" class="chosen-select"
                                AutoPostBack="True" TabIndex="12" >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="ddlColonia" Display="Dynamic" ErrorMessage="INGRESA COLONIA" 
                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCalle" runat="server" Width="470px" TabIndex="13" class="chosen-select"
                                    >
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                    ControlToValidate="ddlCalle" Display="Dynamic" ErrorMessage="INGRESA CALLE" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ENTRE CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="Y CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlEntreCalle" runat="server" Width="470px" TabIndex="14" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                ControlToValidate="ddlEntreCalle" Display="Dynamic" 
                                ErrorMessage="INGRESA ENTRE CALLE" Font-Bold="True" Font-Size="Small" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlYcalle" class="chosen-select" runat="server" Width="470px"  TabIndex="15">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                    ControlToValidate="ddlYcalle" Display="Dynamic" ErrorMessage="INGRESA Y CALLE" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="NUMERO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="MANZANA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="LOTE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNumero" runat="server" Width="190px" MaxLength="10" 
                                style="text-transform :uppercase" TabIndex="16"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtManzana" runat="server" Width="190px" MaxLength="10" 
                                    style="text-transform :uppercase" TabIndex="17"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLote" runat="server" Width="190px" MaxLength="10" 
                                    style="text-transform :uppercase" TabIndex="18"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
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
                <td colspan="4">
                    &nbsp;<asp:Panel ID="Panel7" runat="server" GroupingText="GENERALES" 
                        Font-Bold="True" Font-Size="Medium">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="SEXO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="FECHA NACIMIENTO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ESTADO CIVIL"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="¿SABE LEER Y ESCRIBIR ?"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlSexo" runat="server" Width="200px" TabIndex="19" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                    ControlToValidate="ddlSexo" Display="Dynamic" ErrorMessage="INGRESA SEXO" 
                                    Font-Bold="True" Font-Size="Small" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFecNaci" runat="server" Width="190px" MaxLength="10" 
                                        TabIndex="20"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFecNaci_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecNaci">
                                            </asp:CalendarExtender>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                        ControlToValidate="txtFecNaci" ErrorMessage="FECHA INVALIDA" Font-Bold="True" 
                                        Font-Size="Medium" ForeColor="Red" MaximumValue="31/12/9999" 
                                        MinimumValue="01/01/1111" Display="Dynamic">*</asp:RangeValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" 
                                                ControlToValidate="txtFecNaci" Display="Dynamic" 
                                                ErrorMessage="INGRESA FECHA NACIMINETO **NOTA (EN CASO DE NO TERNER LA FECHA INGRESAR 01/01/1900)" 
                                                ForeColor="#FF3300" ToolTip="EN CASO DE NO TERNER LA FECHA INGRESAR 01/01/1900">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEstadoCivil"  runat="server" Width="200px"  TabIndex="21" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                        ControlToValidate="ddlEstadoCivil" Display="Dynamic" 
                                        ErrorMessage="INGRESA ESTADO CIVIL" ForeColor="#FF3300" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbEscribir" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" 
                                        TabIndex="22">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
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
                                            <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="ESCOLARIDAD"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label28" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="OCUPACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label29" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="IDENTIFICACIÓN"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="FOLIO"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlEscolaridad" runat="server" Width="200px" class="chosen-select"
                                                    TabIndex="23">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                    ControlToValidate="ddlEscolaridad" Display="Dynamic" 
                                                    ErrorMessage="INGRESA ESCOLARIDAD" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlOcupacion" runat="server" Width="200px" TabIndex="24" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                    ControlToValidate="ddlOcupacion" Display="Dynamic" 
                                                    ErrorMessage="INGRESA OCUPACION" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIdentificacion" runat="server" Width="200px" class="chosen-select"
                                                    TabIndex="25">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                                    ControlToValidate="ddlIdentificacion" Display="Dynamic" 
                                                    ErrorMessage="INGRESA IDENTIFICACION" Font-Bold="True" Font-Size="Small" 
                                                    ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFolio" runat="server" Width="190px" MaxLength="20" 
                                                    style="text-transform :uppercase" TabIndex="26"></asp:TextBox>
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
                                            <asp:Label ID="Label33" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="CURP"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="RFC"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblVivo" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="VIVO" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCurp" runat="server" Width="190px" 
                                        style="text-transform :uppercase" TabIndex="27"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRFC" runat="server" Width="190px" 
                                        style="text-transform :uppercase" TabIndex="28"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbVivo" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" 
                                        Visible="False" TabIndex="29">
                                                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                                                <asp:ListItem Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
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
                                            <asp:Label ID="lblDetenido" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="DETENIDO" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="rbDetenido" runat="server" Font-Bold="True" AutoPostBack = "true"
                                                Font-Size="Small" ForeColor="Black" RepeatDirection="Horizontal" TabIndex="30" 
                                                Visible="False" onselectedindexchanged="rbDetenido_SelectedIndexChanged">
                                                <asp:ListItem Value="1">SI</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">

                   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
                    <asp:Panel ID="Paneldetenido" runat="server" Visible="false" style="text-align: center">
                        
                                <br />
                        
                                <asp:Label ID="Label36" runat="server"  class="color-fuente" 
                            style="font-weight: 700; font-size: large; text-align: left;" 
                            Text="EL IMPUTADO ESTA DETENIDO"></asp:Label>
                                <br />
                                <br />
                                <asp:ImageButton ID="IBDetenidoSi" runat="server" ImageUrl="~/img/si.png" onclick="IBDetenidoSi_Click" TabIndex="30"  />
                        &nbsp;<asp:ImageButton ID="IBDetenidoNo" runat="server" ImageUrl="~/img/no.png" onclick="IBDetenidoNo_Click" TabIndex="31" />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="PanelLugarDetencion" runat="server" GroupingText="LUGAR DE LA DETENCIÓN" Font-Bold="True" Visible="false"
                        Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanelLH">
                            <ContentTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style17">
                                            <asp:Label runat="server" Text="FECHA" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                ID="Label56"></asp:Label>
                                        </td>
                                        <td class="style18">
                                            <asp:Label runat="server" Text="HORA:MIN" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                ID="Label57"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            <asp:TextBox runat="server" MaxLength="10" TabIndex="32" Width="170px" ID="txtFecha"></asp:TextBox>
                                            <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" Enabled="True" TargetControlID="txtFecha"
                                                ID="txtFecha_CalendarExtender">
                                            </asp:CalendarExtender>
                                            <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="txtFecha"
                                                ErrorMessage="INGRESA FECHA" Display="Dynamic" ID="RequiredFieldValidator3">*</asp:RequiredFieldValidator>
                                            <asp:RangeValidator runat="server" MaximumValue="31/12/9999" MinimumValue="01/01/1111"
                                                ForeColor="Red" ControlToValidate="txtFecha" ErrorMessage="FECHA INVALIDA" Display="Dynamic"
                                                Font-Bold="True" Font-Size="Medium" ID="RangeValidator3">*</asp:RangeValidator>
                                        </td>
                                        <td class="style18">
                                            <asp:TextBox runat="server" MaxLength="5" TabIndex="33" Width="170px" ID="txtHora"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptAMPM="True"
                                                BehaviorID="_content_MaskedEditExtender3" Century="2000" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="€" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                                CultureDecimalPlaceholder="," CultureName="es-ES" CultureThousandsPlaceholder="."
                                                CultureTimePlaceholder=":" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time"
                                                TargetControlID="txtHora" />
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="Label37" runat="server" Font-Bold="True" ForeColor="Black" 
                                                Text="HRS."></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                            <asp:MaskedEditValidator ID="MaskedEditValidator3" runat="server" 
                                                ControlExtender="MaskedEditExtender3" ControlToValidate="txtHora" 
                                                ErrorMessage="*" ForeColor="Red" InvalidValueMessage="REGISTRE HORA" 
                                                ToolTip="ERROR FORMATO HORA" TooltipMessage="Hora 0:00 am hasta 12:59 pm">
                                            </asp:MaskedEditValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" 
                                                ControlToValidate="txtHora" Display="Dynamic" ErrorMessage="INGRESA HORA" 
                                                Font-Bold="True" Font-Size="Small" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
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
                                        <td class="style17">
                                            <asp:Label ID="Label21" runat="server" Text="TIPO DE LUGAR" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Black"></asp:Label>
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MUNICIPIO"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label44" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LOCALIDAD"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="2">
                                            <asp:DropDownList ID="ddlTipoLugar" runat="server" Width="470px" TabIndex="34" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlTipoLugar"
                                                Display="Dynamic" ErrorMessage="INGRESA TIPO DE LUGAR" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMunicipioLH" runat="server" Width="200px" AutoPostBack="True" class="chosen-select"
                                                TabIndex="35" OnSelectedIndexChanged="ddlMunicipioLH_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlMunicipioLH"
                                                Display="Dynamic" ErrorMessage="INGRESA MUNICIPIO" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocalidadLH" runat="server" Width="200px" AutoPostBack="True" class="chosen-select"
                                                TabIndex="36" OnSelectedIndexChanged="ddlLocalidadLH_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlLocalidadLH"
                                                Display="Dynamic" ErrorMessage="INGRESA LOCALIDAD" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
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
                                        <td class="style17">
                                            <asp:Label ID="Label45" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="COLONIA O FRACCIONAMIENTO"></asp:Label>
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="CALLE "></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="2">
                                            <asp:DropDownList ID="ddlColoniaLH" runat="server" Width="470px" TabIndex="37" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlColoniaLH"
                                                Display="Dynamic" ErrorMessage="INGRESA COLONIA" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlCalleLH" runat="server" Width="470px" TabIndex="38" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlCalleLH"
                                                Display="Dynamic" ErrorMessage="INGRESA CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            <asp:Label ID="Label47" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="ENTRE CALLE"></asp:Label>
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="Y CALLE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="2">
                                            <asp:DropDownList ID="ddlEntreCalleLH" runat="server" Width="470px" TabIndex="39" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlEntreCalleLH"
                                                Display="Dynamic" ErrorMessage="INGRESA ENTRE CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlYcalleLH" runat="server" Width="470px" TabIndex="40" class="chosen-select">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="ddlYcalleLH"
                                                Display="Dynamic" ErrorMessage="INGRESA Y CALLE" Font-Bold="True" Font-Size="Small"
                                                ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
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
                                        <td class="style17">
                                            <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="No. EXTERIOR"></asp:Label>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="MANZANA"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label51" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LOTE"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            <asp:TextBox ID="txtNumeroLH" runat="server" Width="170px" MaxLength="10" TabIndex="41"
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                        <td class="style18">
                                            <asp:TextBox ID="txtManzanaLH" runat="server" Width="170px" MaxLength="10" TabIndex="42"
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLoteLH" runat="server" Width="200px" MaxLength="10" TabIndex="43"
                                                Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            <asp:Label ID="Label52" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LATITUD"></asp:Label>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="Label53" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="LONGITUD"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="Label54" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                                Text="REFERENCIAS"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            <asp:TextBox ID="txtLatitud" runat="server" Width="170px" MaxLength="20" TabIndex="44"
                                                Style="text-transform: uppercase" Enabled="False">0</asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtLatitud"
                                                Display="Dynamic" ErrorMessage="INGRESA LATITUD" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td class="style18">
                                            <asp:TextBox ID="txtLongitud" runat="server" Width="170px" MaxLength="20" TabIndex="45"
                                                Style="text-transform: uppercase" Enabled="False">0</asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtLongitud"
                                                Display="Dynamic" ErrorMessage="INGRESA LONGITUD" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td colspan="2" rowspan="5">
                                            <asp:TextBox ID="txtReferencias" runat="server" Height="85px" TextMode="MultiLine"
                                                Width="470px" MaxLength="250" TabIndex="46" Style="text-transform: uppercase"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                        </td>
                                        <td class="style18">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            <asp:Button ID="cmdMapa" runat="server" OnClick="cmdMapa_Click" Text="ACTUALIZAR MAPA" Visible="false"
                                                TabIndex="47" class="button" />
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            <asp:Label ID="lblMapa" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Visible="false"
                                                Text="MAPA"></asp:Label>
                                        </td>
                                        <td class="style18">
                                        </td>
                                        <td colspan="2" class="style15">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2" colspan="4">
                                            <cc1:GMap ID="GMap1" enableServerEvents="True" serverEventsType="AspNetPostBack" Visible="false"
                                                runat="server" Width="1050px" Height="600px" OnClick="GMap1_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                            &nbsp;
                                        </td>
                                        <td class="style18">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="PanelDetencion" runat="server" GroupingText="DATOS DETENCIÓN" Font-Bold="True" Visible="false"
                        Font-Size="Medium" >
                         <asp:UpdatePanel runat="server" ID="UpdateDetencion">
                            <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEstadoDet2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="ESTADO DEL DETENIDO" Visible="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDisposicion" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="PUESTO A DISPOSICION POR" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label349" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="TIEMPO DE TRASLADO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlEstadoDetenido" runat="server" TabIndex="48" Visible="TRUE" class="chosen-select"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPusoDisposicion" runat="server" TabIndex="49" class="chosen-select"
                                        Visible="False" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTiempoTraslado" runat="server" MaxLength="5" Width="200px" TabIndex="50">00:00</asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptAMPM="True"
                                        BehaviorID="_content_MaskedEditExtender2" Century="2000" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="€" CultureDateFormat="DMY" CultureDatePlaceholder="/"
                                        CultureDecimalPlaceholder="," CultureName="es-ES" CultureThousandsPlaceholder="."
                                        CultureTimePlaceholder=":" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time"
                                        TargetControlID="txtTiempoTraslado" />
                                    <asp:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender2"
                                        ControlToValidate="txtTiempoTraslado" ErrorMessage="*" InvalidValueMessage="REGISTRE HORA"
                                        ForeColor="Red" ToolTip="ERROR FORMATO HORA" TooltipMessage="Hora 0:00 am hasta 12:59 pm">
                                    </asp:MaskedEditValidator>
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
                                <td colspan="4">
                                    <table >
                              <tr>
                              <td>
                                  <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="PROCEDIMIENTO"></asp:Label>
                              </td>
                              <td class="style11">
                                  <asp:RadioButtonList ID="OptProcedimientoDetencion" runat="server" AutoPostBack = "true"
                                      Font-Bold="False" Font-Size="Small" ForeColor="Black" TabIndex="51" 
                                      onselectedindexchanged="OptProcedimientoDetencion_SelectedIndexChanged">
                                      <asp:ListItem Selected="True" Value="1">Flagrancia</asp:ListItem>
                                      <asp:ListItem Value="3">Caso Urgente</asp:ListItem>
                                  </asp:RadioButtonList>
                              </td>
                              <td  >
                                 
                              </td>
                              <td>
                                   <asp:Label ID="lblSupuestoFlagrancia" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="SUPUESTOS DE FLAGRANCIA:"></asp:Label>
                              </td>
                              <td>
                                     <asp:RadioButtonList ID="OptSupuestoFlagrancia" runat="server" 
                                             Font-Bold="False" Font-Size="Small" ForeColor="Black" TabIndex="52" 
                                         style="margin-left: 0px">
                                             <asp:ListItem Selected="True" Value="1">La persona es detenida después de cometer el delito (Código 146 Fracción I)</asp:ListItem>
                                             <asp:ListItem Value="2">La persona es sorprendida cometiendo el delito y es persiguida (Código 145 fracción II a))</asp:ListItem>
                                             <asp:ListItem Value="3">La persona es señalada por la victima u ofendido y tiene pruebas de ello (Código 146 Fracción II b))</asp:ListItem>
                                     </asp:RadioButtonList>  
                               </td>
                              </tr>
                              </table>
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
                                <td colspan="4">
                                    <table>
                              <tr>
                              <td class="style13">
                                  <asp:Label ID="Label9" runat="server" Font-Bold="True" 
                                        Font-Size="Small" ForeColor="Black" Text="LIBERTAD DURANTE LA INVESTIGACION"></asp:Label>
                              </td>
                              <td >
                                  <asp:RadioButtonList ID="rbLibertadInvestigacion" runat="server" 
                                      Font-Bold="False" Font-Size="Small" ForeColor="Black" TabIndex="53" 
                                      
                                      Width="70px" AutoPostBack = "true"
                                      onselectedindexchanged="rbLibertadInvestigacion_SelectedIndexChanged">
                                      <asp:ListItem Selected="True" Value="0">NO</asp:ListItem>
                                      <asp:ListItem Value="1">SI</asp:ListItem>
                                  </asp:RadioButtonList>
                              </td>
                              <td >
                              </td>
                              <td class="style16">
                                   <asp:Label ID="lblmotivoDetencion" runat="server" Font-Bold="True" Visible="false"
                                        Font-Size="Small" ForeColor="Black" Text="MOTIVO DE LA LIBERACIÓN:"></asp:Label>
                              </td>
                              <td>
                                     <asp:RadioButtonList ID="rbMotivoLiberacion" runat="server" Visible="false" 
                                             Font-Bold="False" Font-Size="Small" ForeColor="Black" TabIndex="54">
                                             <asp:ListItem Selected="True" Value="1">No es legal la detención</asp:ListItem>
                                             <asp:ListItem Value="2">No hay flagrancia</asp:ListItem>
                                             <asp:ListItem Value="3">No solicita prisión preventiva como medida cautelar</asp:ListItem>
                                     </asp:RadioButtonList>  
                               </td>
                              </tr>
                              </table>
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                           
                           
                          
                            
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label341" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="DESCRIPCIÓN DE LA DETENCIÓN"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" >
                                    <asp:TextBox ID="txtDescripcionHechos" TextMode="MultiLine"  runat="server" Width="1051px"
                                        Height="96px" TabIndex="55"></asp:TextBox>
                                </td>
                              
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                        Text="FOTOGRAFÍA DEL DETENIDO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:FileUpload ID="ImagenFile" runat="server" class="margen" Height="23px" TabIndex="56"
                                        Width="293px" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Image ID="Ifoto" runat="server" Height="218px" ImageAlign="Middle" Style="margin: 10px;"
                                        Visible="false" Width="270px" />
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
                    </asp:Panel>
                </td>
            </tr>
             <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel8" runat="server" GroupingText="MEDIO DE CONTACTO" 
                        Font-Bold="True" Font-Size="Medium" >
                        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                            <ContentTemplate>
                                <table style="width:100%;">
                                    <tr>
                                        <td class="style5">
                                            <asp:Label ID="Label31" runat="server" Font-Bold="True" Font-Size="Small" 
                                                class="color-fuente" Text="AGREGAR"></asp:Label>
                                            <asp:Button ID="cmdMedio" runat="server" onclick="cmdMedio_Click" Text=" + " 
                                                Width="50px" class="button" />
                                        </td>
                                        <td class="style3">
                                            &nbsp;</td>
                                        <td class="style4">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="gvMedio" runat="server" CellPadding="4" 
                                                ForeColor="#333333" GridLines="None" Width="472px" 
                                                AutoGenerateColumns="False" DataSourceID="dsMedioContacto">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="EDITAR">
                                                        <ItemTemplate>
                                                            <a href='MedioContacto.aspx?ID_PERSONA=<%#Eval("ID_PERSONA")%>&amp;&amp;op=Modificar&amp;ID_MEDIO_CONTACTO=<%#Eval("ID_MEDIO_CONTACTO")%>&amp;'>
                                                            <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" 
                                 Width="18px" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID_MEDIO_CONTACTO" HeaderText="ID_MEDIO_CONTACTO" 
                                                        SortExpression="ID_MEDIO_CONTACTO" Visible="False" />
                                                    <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" 
                                                        SortExpression="ID_PERSONA" Visible="False" />
                                                    <asp:BoundField DataField="TIPO_MEDIO_CONTACTO" 
                                                        HeaderText="TIPO DE CONTACTO" SortExpression="TIPO_MEDIO_CONTACTO" />
                                                    <asp:BoundField DataField="MEDIO_CONTACTO" HeaderText="MEDIO DE CONTACTO" 
                                                        SortExpression="MEDIO_CONTACTO" />
                                                </Columns>
                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                                        HorizontalAlign="Left" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" 
                                                    HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" 
                                                    ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style5">
                                            <asp:SqlDataSource ID="dsMedioContacto" runat="server" 
                                                ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                                                SelectCommand="consultaMedioContacto" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ID_PERSONA" Name="IdPersona" 
                                                        PropertyName="Text" Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                        <td class="style3">
                                            &nbsp;</td>
                                        <td class="style4">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                                            <asp:Label ID="lblDecIm" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="DECLARACION DEL IMPUTADO"></asp:Label>
                                            <asp:Label ID="lblDecTes" runat="server" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="Black" Text="DECLARACION TESTIMONIAL"></asp:Label>
                                        </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:TextBox ID="txtDeclaracion" runat="server" Height="250px" TextMode="MultiLine" TabIndex="57" 
                        Width="1000px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">

                   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
                    <asp:Panel ID="Panel2" runat="server" style="text-align: center">
                        
                                <br />
                        
                                <asp:Label ID="lblSuspender" runat="server"  class="color-fuente" 
                            style="font-weight: 700; font-size: large; text-align: left;" 
                            Text="DENUNCIANTE ES EL MISMO QUE EL OFENDIDO"></asp:Label>
                                <br />
                                <br />
                                <asp:ImageButton ID="ImgSi1" runat="server" ImageUrl="~/img/si.png" 
                            onclick="ImgSi1_Click" />
                        &nbsp;<asp:ImageButton ID="ImgNo1" runat="server" ImageUrl="~/img/no.png" 
                            onclick="ImgNo1_Click" />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" 
                        Font-Size="Small" ForeColor="Red" Width="1111px" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">

                   
                    
                    <asp:Button ID="cmdGu" runat="server" onclick="cmdGu_Click" Text="GUARDAR" 
                        Width="156px" TabIndex="58" Font-Bold="True" Height="40px" class="button"  />
                    &nbsp;
                    <asp:Button ID="cmdReg" runat="server" onclick="cmdReg_Click" Text="REGRESAR" 
                        Width="156px" TabIndex="59" Font-Bold="True" Height="40px" class="button" />
                 

                    


                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
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

