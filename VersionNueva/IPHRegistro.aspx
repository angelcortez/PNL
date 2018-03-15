<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IPHRegistro.aspx.cs" Inherits="AtencionTemprana.IPHRegistro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            text-align: left;
        }
        .style3
        {
            font-size: medium;
            }
        .style8
        {
        }
        .style12
        {
        }
        .style14
        {
        }
        .style15
        {
            background-color: #C0C0C0;
        }
        .style17
        {
            background-color: #000000;
        }
        .style18
        {
            color: #FFFFFF;
        }
        .style19
        {
        }
        .style20
        {
            height: 20px;
            }
        .style31
        {
            text-decoration: underline;
        }
        .style32
        {
        }
        .style33
        {
        }
        .style34
        {
            background-color: #C0C0C0;
        }
        .style35
        {
            height: 19px;
        }
        .style36
        {
            background-color: #000000;
        }
        .style40
        {
        }
        .style44
        {
        }
        .style47
        {
            height: 18px;
        }
        .style48
        {
            height: 14px;
        }
        .style49
        {
            width: 940px;
        }
        .style56
        {
            width: 188px;
        }
        
        .Style-Texbox
        {
           margin:0 auto;
            
            
        }
        
        .style-labelsTitulos
        {
             color:White;
             font-size:medium;
             font-weight:700;
             
         
        }
        
        .style-celdaTitulos
        {
            background-color:#006230;
                
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
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" ForeColor="#006600" 
                    Font-Size="Medium"></asp:Label>
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
                  <asp:TextBox ID="txtFechaInformeIPH" runat="server" 
                      Width="97px"></asp:TextBox>
                  <asp:CalendarExtender ID="txtFechaInformeIPH_CalendarExtender" runat="server" 
                      Enabled="True" TargetControlID="txtFechaInformeIPH">
                  </asp:CalendarExtender>
              </td>
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
     
      
          <tr>
              <td>   <h2> 

                  <asp:Label ID="lblOperacionIPH" runat="server" Font-Bold="True" 
                      ForeColor="#006600"></asp:Label>
                         </h2> 
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
                  <asp:Label ID="ID_IPH" runat="server" ForeColor="Red" Visible="False"></asp:Label>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td align="right">
                  &nbsp;</td>
          </tr>
     
      
    </table>    
    


    

        <table class="style49" border="5" align="center" bgcolor="White">

            <tr>
                <td class="style3" colspan="5">
                    <strong style="text-align: center">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    Informe Policial Homologado</strong></td>
            </tr>
        <%--    <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="AGREGAR USUARIO"></asp:Label>
                    &nbsp;
                    <asp:Button ID="cmdUsuario" runat="server" Text="+" onclick="cmdUsuario_Click" 
                        Width="40px" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp; &nbsp;
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Vertical" Width="900px" AllowPaging="True" 
                        AutoGenerateColumns="False" DataSourceID="dsConsulrtaUsuario">
                        <Columns>
                        <asp:TemplateField HeaderText=" ">
                                                    <ItemTemplate>
                                                    <a href='Usuarios.aspx?ID_USUARIO=<%#Eval("ID_USUARIO")%>&amp;op=Modificar&amp;'>
                                                    
                                                    <asp:Image ID="Image1" runat="server" Height="18px" ImageUrl="img/view-tree.png" /></a>
                                                                    </ItemTemplate>
                                                                    </asp:TemplateField>
                            <asp:BoundField DataField="ID_USUARIO" HeaderText="ID_USUARIO" 
                                SortExpression="ID_USUARIO" Visible="False" />
                            <asp:BoundField DataField="PTRNO" HeaderText="PATERNO" SortExpression="PTRNO" />
                            <asp:BoundField DataField="MTRNO" HeaderText="MATERNO" SortExpression="MTRNO" />
                            <asp:BoundField DataField="NMBRE" HeaderText="NOMBRE" SortExpression="NMBRE" />
                            <asp:BoundField DataField="FCHA_ALTA" HeaderText="FECHA ALTA" 
                                SortExpression="FCHA_ALTA" />
                            <asp:CheckBoxField DataField="ACTVO" HeaderText="ACTIVO" 
                                SortExpression="ACTVO" />
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
                <td align="center" colspan="3">
                    <asp:SqlDataSource ID="dsConsulrtaUsuario" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:PGJ_NSJPConnectionString2 %>" 
                        SelectCommand="ConsultaUsuario" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td colspan="5" class="style2">
                    &nbsp;<strong> Llenado conforme el art.41 fraccion I de la Ley General del sistema 
                    nacional de serguridad publica; asi como al art. 124 del Codigo de Proc. Penales 
                    del Estado de Tamaulipas.</strong></td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;


                      
                     <asp:TextBox ID="TextBox1" runat="server" Width="220px" MaxLength="10" 
                        height="19" Visible="False" ></asp:TextBox>

                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="TextBox1">
                    </asp:CalendarExtender>

                    
                    </td>
            </tr>
            
            <tr class="style-celdaTitulos">
                <td class="style-labelsTitulos" colspan="5">

                    <asp:Label ID="lblDatosGeneralesIPH" runat="server" CssClass="style-labelsTitulos"

                         Text="DATOS GENERALES"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="style33" >

    
                    <asp:Label ID="lblFolioIPH" runat="server" Text="Folio:"  AssociatedControlID="txtFolioIPH"
                        style="font-size: medium"></asp:Label>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


                    <asp:TextBox ID="txtFolioIPH" runat="server" Width="174px" class="Style-Texbox" 
                        Height="19px" ></asp:TextBox>


                    &nbsp;&nbsp;


                 <asp:RequiredFieldValidator ID="reqFV_Folio" runat="server" 
                        ControlToValidate="txtFolioIPH" 
                        ErrorMessage='El campo Folio' EnableClientScript="true"  
                       SetFocusOnError="true"  Text="*"   ForeColor="#CC3300" Font-Bold="True" 
                        Font-Size="X-Large"  ></asp:RequiredFieldValidator>  






                </td>
                <td class="style44" colspan="2">
                    &nbsp;
                    
                    <asp:Label ID="lblNoOficio" runat="server" Text="No. de Oficio: "  AssociatedControlID="txtOficioIPH"
                        style="font-size: medium;"></asp:Label>
                    
                    <asp:TextBox ID="txtOficioIPH" runat="server"></asp:TextBox>
                    
                   <asp:RequiredFieldValidator ID="reqFV_NoOficio" runat="server" 
                        ControlToValidate="txtOficioIPH" 
                        ErrorMessage='El campo NO. Oficio' EnableClientScript="true"  
                        SetFocusOnError="true"  Text="*"   ForeColor="#CC3300" Font-Bold="True" 
                        Font-Size="X-Large"  ></asp:RequiredFieldValidator>  



                    </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblFechaEventoIPH" runat="server" Text="Fecha del evento"  AssociatedControlID="txtFechaEventoIPH" 
                        style="font-size: medium;"></asp:Label>


                    <asp:TextBox ID="txtFechaEventoIPH" runat="server" Width="250px" MaxLength="10" 
                        height="22px" ></asp:TextBox>

                       <asp:CalendarExtender ID="txtFechaEventoIPH_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFechaEventoIPH">
                    </asp:CalendarExtender>



                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="txtFechaEventoIPH" Display="Dynamic" 
                                                ErrorMessage="INGRESAAAAAAAAA" Font-Bold="True" Font-Size="Medium" 
                                                ForeColor="Red">*</asp:RequiredFieldValidator>



                  
                

                    <asp:Label ID="lblHoraEventoIPH" runat="server" Text="Hora del Evento :" AssociatedControlID="txtHoraEventoIPH"
                        style="font-size: medium;"></asp:Label>
                  
                    <asp:TextBox ID="txtHoraEventoIPH" runat="server" Width="123px"></asp:TextBox>


                       <asp:RequiredFieldValidator ID="reqFV_HoraEvento" runat="server"  ControlToValidate="txtHoraEventoIPH" 
                        ErrorMessage='El campo Hora de Evento' EnableClientScript="true"  
                        SetFocusOnError="true"  Text="*"   ForeColor="#CC3300" Font-Bold="True" 
                        Font-Size="X-Large"  ></asp:RequiredFieldValidator>  


                    



                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19" colspan="5">
                    <asp:Label ID="lblAsuntoIPH" runat="server" Text="Asunto : " AssociatedControlID="txtAsuntoDT_IPH" 
                        style="font-size: medium;"></asp:Label>
                    <asp:TextBox ID="txtAsuntoDT_IPH" runat="server" Width="799px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtAsuntoDT_IPH" 
                        ErrorMessage='El campo Asunto' EnableClientScript="true"  
                        SetFocusOnError="true"  Text="*"   ForeColor="#CC3300" Font-Bold="True" 
                        Font-Size="X-Large"  ></asp:RequiredFieldValidator>  


                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style20" colspan="5">
                    <asp:Label ID="lblDirigidoaIPH" runat="server" Text="Dirigido a :" 
                        style="font-size: medium;"></asp:Label>
                    <asp:TextBox ID="txtDirigidoDT_IPH" runat="server" Width="777px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19" colspan="5">
                    <asp:Label ID="lblAgentesIPH" runat="server" Text="Agentes :" 
                        style="font-size: medium;"></asp:Label>
                    <asp:TextBox ID="txtAgentesDT_IPH" runat="server" Width="787px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19" colspan="2">
                    <asp:Label ID="lblParticipacionIPH" runat="server" Text="Participacion :" 
                        style="font-size: medium;"></asp:Label>
                    &nbsp;
                    
                   


                    <asp:DropDownList ID="ddlParticipacionDT_IPH" runat="server">
                    </asp:DropDownList>
                    
                   


                </td>
                <td class="style19" colspan="3">
                    <asp:Label ID="lblOperativoIPH" runat="server" style="font-size: medium;" 
                        Text="Operativo :"></asp:Label>
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButtonList ID="rblOperativo_IPH" runat="server" 
                        RepeatDirection="Horizontal" Width="127px">
                        <asp:ListItem Value="1">SI</asp:ListItem>
                        <asp:ListItem Value="0">NO</asp:ListItem>
                    </asp:RadioButtonList>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8" colspan="5">
                    <asp:Label ID="lblFolioIPH8" runat="server" style="font-size: medium;" 
                        Text="Nombre del Comandante del Operativo :"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtNomComanDT_IPH" runat="server" Width="556px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>


            <tr class="style-celdaTitulos" >
                <td  class="style-labelsTitulos"  colspan="5">
                    <asp:Label ID="lblMOTIVOIPH" runat="server" 
                        Text="MOTIVO (Clasificacion del Evento)"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19" colspan="5">
                    <asp:Label ID="lblTipoEventoIIPH" runat="server" style="font-size: medium;" 
                        Text="Tipo de Evento :"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtTipoEvenMot_IPH" runat="server" Width="718px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos" >
                <td class="style-labelsTitulos"  colspan="5">
                    <asp:Label ID="lblUbicacionIPH" runat="server" 
                        style="font-size: medium; font-weight: 700" Text="UBICACION"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19" colspan="3">
                    <asp:Label ID="lblEstadoIPH" runat="server" style="font-size: medium;" 
                        Text="Estado :"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtEstadoUbi_IPH" runat="server" Width="377px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblMunicipioIPH" runat="server" style="font-size: medium;" 
                        Text="Municipio :"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtMunicipioUbi_IPH" runat="server" Width="306px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style35" colspan="5">
                    </td>
            </tr>
            <tr>
                <td class="style19" colspan="3">
                    <asp:Label ID="lblLocalidadIPH" runat="server" style="font-size: medium;" 
                        Text="Localidad :"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtLocalidadUbi_IPH" runat="server" Width="352px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblColoniaIPH" runat="server" style="font-size: medium;" 
                        Text="Colonia :"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtColoniaUbi_IPH" runat="server" Width="317px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblCalleIPH" runat="server" style="font-size: medium;" 
                        Text="Calle :"></asp:Label>
                    <asp:TextBox ID="txtCalleUbi_IPH" runat="server" Width="270px"></asp:TextBox>
                </td>
                <td class="style44" colspan="2">
                    <asp:Label ID="lblNoExtIPH" runat="server" style="font-size: medium;" 
                        Text="No. Ext."></asp:Label>
                    <asp:TextBox ID="txtNoExtUbi_IPH" runat="server" Width="87px"></asp:TextBox>
                </td>
                <td class="style40">
                    <asp:Label ID="lblNoIntIPH" runat="server" style="font-size: medium;" 
                        Text="No. Int. "></asp:Label>
                    &nbsp;<asp:TextBox ID="txtNoIntUbi_IPH" runat="server" Width="112px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblCPIPH" runat="server" style="font-size: medium;" Text="C.P."></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtCPUbi_IPH" runat="server" Width="127px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19" colspan="5">
                    <asp:Label ID="lblReferenciaIPH" runat="server" style="font-size: medium;" 
                        Text="Referencia :"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtReferenUbi_IPH" runat="server" Width="764px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19" colspan="4">
                    <asp:Label ID="lblCaminosIPH" runat="server" style="font-size: medium;" 
                        Text="Caminos:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chbCaminosUbi_IPH" runat="server" Text=" " />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTramoCarreteroIPH" runat="server" style="font-size: medium;" 
                        Text="Tramo Carretero :"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtTramoCarreUbi_IPH" runat="server" Width="348px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblKilometroIPH" runat="server" style="font-size: medium;" 
                        Text="Kilometro :"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtKilometroUbi_IPH" runat="server" Width="87px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr  class="style-celdaTitulos" >
                <td class="style-labelsTitulos" colspan="5">
                    <asp:Label ID="lblDescHechosIPH" runat="server" 
                        style="font-size: medium; font-weight: 700" Text="DESCRIPCION DE LOS HECHOS"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style32" colspan="5">
                    &nbsp;
                    <asp:TextBox ID="txtDescHechosUbi_IPH" runat="server" Height="142px" 
                        Width="853px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style31" colspan="5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr  class="style-celdaTitulos" >
                <td  class="style-labelsTitulos"  colspan="5">
                    <asp:Label ID="lblPersonasInvoIPH" runat="server" 
                        style="font-size: medium; font-weight: 700" Text="PERSONAS INVOLUCRADAS"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style19" colspan="3">
                    <asp:Label ID="lblApePaternoIPH" runat="server" style="font-size: medium;" 
                        Text="Apellido Paterno :"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtApePaternoPI_IPH" runat="server" Width="334px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblApeMatIPH" runat="server" style="font-size: medium;" 
                        Text="Apellido Materno :"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtApeMaternoPI_IPH" runat="server" Width="263px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style8" colspan="5">
                    <asp:Label ID="lblNombresIPH" runat="server" style="font-size: medium;" 
                        Text="Nombres:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtNombresPI_IPH" runat="server" Width="806px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblAliasIPH" runat="server" style="font-size: medium;" 
                        Text="Alias:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtAliasPI_IPH" runat="server" Width="102px"></asp:TextBox>
                </td>
                <td class="style44" colspan="2">
                    <asp:Label ID="lblNacioIPH" runat="server" style="font-size: medium;" 
                        Text="Nacionalidad:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtNacionaPI_IPH" runat="server" Width="98px"></asp:TextBox>
                </td>
                <td class="style40">
                    <asp:Label ID="lblMenoEdadIPH" runat="server" style="font-size: medium;" 
                        Text="Menor de Edad :"></asp:Label>
                    <asp:RadioButton ID="rdbMenorEdadPI_IPH" runat="server" Text=" " />
                </td>
                <td class="style56">
                    <asp:Label ID="lblMayorEdadIPH" runat="server" style="font-size: medium;" 
                        Text="Mayor de Edad:"></asp:Label>
                    <asp:RadioButton ID="rdbMayorEdadPI_IPH" runat="server" Text=" " />
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblFechaNacimIPH" runat="server" style="font-size: medium;" 
                        Text="Fecha de Nacimiento:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtFechaNacPI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style44" colspan="2">
                    <asp:Label ID="lblEdadIPH" runat="server" style="font-size: medium;" 
                        Text="Edad:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEdadPI_IPH" runat="server" Width="102px"></asp:TextBox>
                </td>
                <td class="style40">
                    <asp:Label ID="lblRFCIPH" runat="server" style="font-size: medium;" 
                        Text="R.F.C."></asp:Label>
                    &nbsp;<asp:TextBox ID="txtRFCPI_IPH" runat="server" Width="160px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblSexoIPH" runat="server" style="font-size: medium;" 
                        Text="Sexo:"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlSexoPI_IPH" runat="server" Height="16px" Width="170px">
                    </asp:DropDownList>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8" colspan="5">
                    <asp:Label ID="lblDomicilioIPH" runat="server" style="font-size: medium;" 
                        Text="Domicilio:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtDomicilioPI_IPH" runat="server" Width="814px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblClasificacionIPH" runat="server" style="font-size: medium;" 
                        Text="Clasificacion:"></asp:Label>
                    <asp:DropDownList ID="txtClasifiPI_IPH" runat="server" Height="16px" 
                        style="height: 22px; width: 77px" Width="170px">
                    </asp:DropDownList>
                </td>
                <td class="style44" colspan="2">
                    <asp:Label ID="lblSituacionIPH" runat="server" style="font-size: medium;" 
                        Text="Situacion:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlSituacionPI_IPH" runat="server" Height="16px" 
                        Width="170px">
                    </asp:DropDownList>
                </td>
                <td class="style40">
                    <asp:Label ID="lblEnCalidadIPH" runat="server" style="font-size: medium;" 
                        Text="En calidad de :"></asp:Label>
                    <asp:DropDownList ID="ddlEnCalidadPI_IPH" runat="server" Height="16px" 
                        Width="170px">
                    </asp:DropDownList>
                </td>
                <td class="style56">
                    <asp:Label ID="lblEstatusResidencialIPH" runat="server" 
                        style="font-size: medium;" Text="Estatus Residencial :"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlEstatusRedPI_IPH" runat="server" Height="16px" 
                        Width="170px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblOrigenIPH" runat="server" style="font-size: medium;" 
                        Text="Origen :"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtOrigenPI_IPH" runat="server" Width="418px"></asp:TextBox>
                </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblDestinoIPH" runat="server" style="font-size: medium;" 
                        Text="Destino :"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtDestinoPI_IPH" runat="server" Width="338px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;
                </td>
            </tr>
            <tr class="style-celdaTitulos">
                <td  class="style-labelsTitulos"  colspan="5">
                    <asp:Label ID="lblProbablesDelitosIPH" runat="server" 
                        style="font-size: medium; font-weight: 700;" 
                        Text="PROBABLES DELITOS O FALTAS ADMINISTRATIVAS "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:TextBox ID="txtProbablesDelitos_IPH" runat="server" Width="910px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos" >
                <td  class="style-labelsTitulos"  colspan="5">
                    <asp:Label ID="lblOtrosDatosIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="OTROS DATOS"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style48" colspan="5">
                    </td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblOcupacionIPH" runat="server" style="font-size: medium;" 
                        Text="Ocupacion: "></asp:Label>
                    <asp:TextBox ID="txtOcupacionOD_IPH" runat="server" Width="384px"></asp:TextBox>
                </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblEscolaridadIPH" runat="server" style="font-size: medium;" 
                        Text="Escolaridad:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEscolaridadOD_IPH" runat="server" Width="317px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblTelPartiIPH" runat="server" style="font-size: medium;" 
                        Text="Telefono Particular:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtTelPartOD_IPH" runat="server" Width="323px"></asp:TextBox>
                </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblTelCelIPH" runat="server" style="font-size: medium;" 
                        Text="Telefonon Celular:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtTelCelOD_IPH" runat="server" Width="295px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblObservacionesOtrosIPH" runat="server" 
                        style="font-size: medium;" Text="Observaciones:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtObservaOD_IPH" runat="server" Width="784px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos">
                <td class="style-labelsTitulos"  colspan="5">
                    <asp:Label ID="lblDatosDetencionIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="DATOS DE LA DETENCION"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblMotivoDetencionIPH" runat="server" style="font-size: medium;" 
                        Text="Motivo de la detencion:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtMotivoDeteDD_IPH" runat="server" Width="727px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblUbicacionDeteIPH" runat="server" style="font-size: medium;" 
                        Text="Ubicacion del Detenido:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtUbicacionDeteDD_IPH" runat="server" Width="722px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblAutoridadDispoIPH" runat="server" style="font-size: medium;" 
                        Text="Autoridad a la que fue puesta a disposicion:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtAutoridadDispoDD_IPH" runat="server" Width="584px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblNombreCargoRecibioIPH" runat="server" 
                        style="font-size: medium;" Text=" Nombre y cargo de quien lo recibio:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtNombreCargoRecibioDD_IPH" runat="server" Width="639px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos">
                <td class="style-labelsTitulos"  colspan="5">
                    <asp:Label ID="lblMediosTransporteIPH" runat="server" 
                        style="font-size: medium; font-weight: 700;" 
                        Text="Medios de transporte involucrados"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblTipoMediosIPH" runat="server" style="font-size: medium;" 
                        Text="Tipo:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlTipoMTI_IPH" runat="server" Height="16px" 
                        Width="317px">
                    </asp:DropDownList>
                </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblEspecifiqueMedIPH" runat="server" style="font-size: medium;" 
                        Text="Especifique:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtEspecifiqueMTI_IPH" runat="server" Width="328px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    &nbsp;
                    <asp:DropDownList ID="DropDownList6" runat="server" Height="16px" Width="349px">
                    </asp:DropDownList>
                    &nbsp;</td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblRecuperadoMedIPH" runat="server" style="font-size: medium;" 
                        Text="Recuperado:"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlRecuperadoMTI_IPH" runat="server" Height="20px" 
                        Width="243px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblMarcaMedIPH" runat="server" style="font-size: medium;" 
                        Text="Marca:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtMarcaMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style44" colspan="3">
                    <asp:Label ID="lblSubMarcaMedIPH" runat="server" style="font-size: medium;" 
                        Text="SubMarca:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtSubMarcaMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblModeloAnoMedIPH" runat="server" style="font-size: medium;" 
                        Text="Modelo/Año:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtModeloAnoMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td class="style44" colspan="2">
                    &nbsp;</td>
                <td class="style40">
                    &nbsp;</td>
                <td class="style56">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblPlacasMedIPH" runat="server" style="font-size: medium;" 
                        Text="Placas:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtPlacasMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style44" colspan="2">
                    <asp:Label ID="lblColorMedIPH" runat="server" style="font-size: medium;" 
                        Text="Color:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtColorMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style40">
                    <asp:Label ID="lblNumMotorMedIPH" runat="server" style="font-size: medium;" 
                        Text="Numero de Motor:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtNumMotorMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblSerieMedIPH" runat="server" style="font-size: medium;" 
                        Text="Serie:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtSerieMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblRegNivIPH" runat="server" style="font-size: medium;" 
                        Text="Registro/NIV :"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtRegistroNivMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style44" colspan="2">
                    <asp:Label ID="lblProcedenciaIPH" runat="server" style="font-size: medium;" 
                        Text="Procedencia:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtProcedenciaMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblEmpresaMedIPH" runat="server" style="font-size: medium;" 
                        Text="Empresa:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtEmpresaMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblCapyTipoCargaMedIPH" runat="server" 
                        style="font-size: medium;" Text="Capacidad de Carga/Tipo de Carga:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCapacidadCargaMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style40">
                    <asp:Label ID="lblOrigenMedIPH" runat="server" style="font-size: medium;" 
                        Text="Origen:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtOrigenMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblDestinoMedIPH" runat="server" style="font-size: medium;" 
                        Text="Destino:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtDestinoMTI_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblObservacionesMedIPH" runat="server" 
                        style="font-size: medium;" Text="Observaciones:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtObservacionesMTI_IPH" runat="server" Width="449px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos">
                <td class="style-labelsTitulos" colspan="5">
                    <asp:Label ID="lblArmasAseguradasIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="Armas Aseguradas"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblTipoArmaIPH" runat="server" style="font-size: medium;" 
                        Text="Tipo de Arma:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlTipoArmaAA_IPH" runat="server" Height="16px" 
                        Width="290px">
                    </asp:DropDownList>
                </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblDescripArmaIPH" runat="server" style="font-size: medium;" 
                        Text="Descripcion:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtDescAA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblArmasIPH" runat="server" style="font-size: medium;" 
                        Text="Armas:"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlArmasAA_IPH" runat="server" Height="16px" 
                        Width="152px">
                    </asp:DropDownList>
                </td>
                <td class="style44" colspan="2">
                    <asp:Label ID="lblMarcaArmaIPH" runat="server" style="font-size: medium;" 
                        Text="Marca:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtMarcaAA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style40">
                    <asp:Label ID="lblTipoArmaAseIPH" runat="server" style="font-size: medium;" 
                        Text="Tipo:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtTipoAA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblCalibreArmaIPH" runat="server" style="font-size: medium;" 
                        Text="Calibre:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCalibreAA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblMatriculaArmaIPH" runat="server" style="font-size: medium;" 
                        Text="Matricula:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtMatriculaAA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style40" colspan="2">
                    <asp:Label ID="lblSerieArmaIPH" runat="server" style="font-size: medium;" 
                        Text="Serie:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtSerieAA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos" >
                <td  class="style-labelsTitulos" colspan="5">
                    <asp:Label ID="lblDrogaAseguradaIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="Droga Asegurada"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblTipoDrogaIPH" runat="server" style="font-size: medium;" 
                        Text="Tipo:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtTipoDA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style44" colspan="3">
                    <asp:Label ID="lblUnMedDrogaIPH" runat="server" style="font-size: medium;" 
                        Text="Unidad de Medida:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtUnidadMedidaDA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style56">
                    <asp:Label ID="lblCantidadDrogaIPH" runat="server" style="font-size: medium;" 
                        Text="Cantidad:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtCantidadDA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblObservacionesDrogaIPH" runat="server" 
                        style="font-size: medium;" Text="Observaciones:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtObservaDA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos" >
                <td class="style-labelsTitulos" colspan="5">
                    <asp:Label ID="lblObjetosAseIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="Otros Objetos Asegurados"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="3">
                    <asp:Label ID="lblTipoObjetoIPH" runat="server" style="font-size: medium;" 
                        Text="Tipo de Objeto:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtTipoObjetoOOA_IPH" runat="server" Width="205px"></asp:TextBox>
                </td>
                <td class="style40">
                    <asp:Label ID="lblCantidadObjetoIPH" runat="server" style="font-size: medium;" 
                        Text="Cantidad:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtCantidadOOA_IPH" runat="server" Width="66px"></asp:TextBox>
                </td>
                <td class="style56">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblDescripObjetoIPH" runat="server" style="font-size: medium;" 
                        Text="Descripcion:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtDescOOA_IPH" runat="server" Width="799px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr  class="style-celdaTitulos" >
                <td class="style-labelsTitulos" colspan="5">
                    <asp:Label ID="lblInfCompleEventoIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="Informacion Complementaria del Evento"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblTipoInfCompIPH" runat="server" style="font-size: medium;" 
                        Text="Tipo:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:CheckBoxList ID="chblTipoInfoComple_IPH" runat="server" Height="27px" 
                        RepeatDirection="Horizontal" Width="443px">
                        <asp:ListItem Value="0">Video</asp:ListItem>
                        <asp:ListItem Value="1">Imagen</asp:ListItem>
                        <asp:ListItem Value="2">Audio</asp:ListItem>
                        <asp:ListItem Value="3">demo</asp:ListItem>
                    </asp:CheckBoxList>
                    </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblDescInfoComIPH" runat="server" style="font-size: medium;" 
                        Text="Descripcion:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtDescICE_IPH" runat="server" Width="799px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr class="style-celdaTitulos">
                <td  class="style-labelsTitulos" colspan="5">
                    <asp:Label ID="lblDictamenMedIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="Dictamen Medico"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33">
                    <asp:Label ID="lblDictamenMedIPH2" runat="server" style="font-size: medium;" 
                        Text="Dictamen Medico:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;<asp:RadioButtonList ID="rblDictamenMeidocIPH" runat="server" 
                        RepeatDirection="Horizontal" Width="127px">
                        <asp:ListItem Value="1">SI</asp:ListItem>
                        <asp:ListItem Value="0">NO</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style44" colspan="3">
                    <asp:Label ID="lblFechaDictamenIPH" runat="server" style="font-size: medium;" 
                        Text="Fecha del Dictamen:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtFechaDictamenICE_IPH" runat="server" Width="198px"></asp:TextBox>
                    </td>
                <td class="style56">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style14" colspan="5">
                    <asp:Label ID="lblInfoGeneIPH" runat="server" style="font-size: medium; font-weight: 700;" 
                        Text="Observaciones Generales del Informe"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td class="style44" colspan="2">
                    &nbsp;</td>
                <td class="style40">
                    &nbsp;</td>
                <td class="style56">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style47" colspan="5">
                    &nbsp;<asp:TextBox ID="txtObservaGeneraInfo_IPH" runat="server" Width="882px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnHuellaRegistroIPH" runat="server" Height="150px" 
                        Width="150px" />
                </td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                    <asp:Label ID="lblEstatusIPH" runat="server" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style33">
                    &nbsp;</td>
                <td class="style44" colspan="2">
                    <asp:Button ID="btnGuardarInformePH" runat="server" 
                        onclick="btnGuardarInformePH_Click" Text="GUARDAR INFORME" Width="220px" />
                </td>
                <td class="style40">


                    <asp:Button ID="btnCancelarInformePH" runat="server" 
                        onclick="btnCancelarInformePH_Click" Text="CANCELAR INFORME" Width="220px" />



                </td>
                <td class="style56">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style33" colspan="5">
                     <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="LOS SIGUIENTES CAMPOS SON OBLIGATORIOS: "
                      ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" 
                         Font-Bold="True" Font-Size="Small" ForeColor="#FF3300"  />  

                     
                     </td>
            </tr>
       
       
       </table>

       

    </ContentTemplate>
    </asp:UpdatePanel>  
    
</div>

</asp:Content>

