﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocPdf.aspx.cs" Inherits="AtencionTemprana.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function mostrarFichero(destino) {
            window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
            document.forms(0).submit();
        }
    
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
<div id="main-wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
                <asp:PostBackTrigger ControlID="ddlPlantilla" />
                <asp:PostBackTrigger ControlID="cmdGeneraPdf" />
                <asp:PostBackTrigger ControlID="cmdGuardar" />
                <asp:PostBackTrigger ControlID="cmdReg" />
    </Triggers>
    <ContentTemplate>
    <table style="width: 100%;">
        <tr>
            <td>
                
                <asp:Label ID="UNDD" runat="server" Font-Bold="True" class="color-fuente" 
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
                  &nbsp;</td>
          </tr>
     
      
          <tr>
              <td>
                  <asp:Label ID="IdCarpeta" runat="server" Visible="False"></asp:Label>
              </td>
              <td>
                  <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
              </td>
              <td>
                  <asp:Label ID="IdPdf" runat="server" Visible="False"></asp:Label>
              </td>
              <td align="right">
                  <asp:Label ID="ID_PLANTILLA" runat="server" Visible="False"></asp:Label>
              </td>
          </tr>
     
      
    </table>  
    
     <h2> 
        <asp:Label ID="lblOperacion" runat="server" class="color-fuente"></asp:Label></h2>
     
    <table style="width: 100%;">
        <tr>
            <td colspan="3">
                    <asp:Panel ID="Panel34" runat="server" GroupingText="-">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label398" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="DENUNCIANTE"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label399" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="OFENDIDO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label400" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="IMPUTADO"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlDenunciante" runat="server" Width="280px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOfendido" runat="server" Width="280px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlImputado" runat="server" Width="280px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label460" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="TESTIGO"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label461" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="DEFENSOR"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlTestigo" runat="server" Width="280px" class="chosen-select">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDefensor" runat="server" Width="280px" class="chosen-select">
                                    </asp:DropDownList>
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
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                                        ForeColor="Black" Text="DOCUMENTO"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlPlantilla" runat="server" AutoPostBack="True" class="chosen-select"
                                        onselectedindexchanged="ddlPlantilla_SelectedIndexChanged" Width="750px">
                                       
                                        <%--<asp:ListItem Value="0">SELECCIONE DOCUMENTO</asp:ListItem>
                                        <asp:ListItem Value="3">ACTA DE DENUNCIA Y/O QUERRELLA</asp:ListItem>
                                        <asp:ListItem Value="4">ACTA DE LECTURA Y EXPLICACION DE DERECHOS A LA VICTIMA/OFENDIDO</asp:ListItem>
                                        <asp:ListItem Value="5">ACUERDO DE INCOMPETENCIA</asp:ListItem>
                                        <asp:ListItem Value="6">ACUERDO DE INICIO</asp:ListItem>
                                        <asp:ListItem Value="7">ACUERDO PARA ABSTENERSE DE INVESTIGAR</asp:ListItem>
                                        <asp:ListItem Value="8">ARCHIVO TEMPORAL</asp:ListItem>
                                        <asp:ListItem Value="9">DECLARACION DEL IMPUTADO</asp:ListItem>
                                        <asp:ListItem Value="10">DECLARACION TESTIMONIAL</asp:ListItem>
                                        <asp:ListItem Value="11">EXAMEN DE LA DETENCION</asp:ListItem>
                                        <asp:ListItem Value="12">INEJERCICIO POR PERDON</asp:ListItem>
                                        <asp:ListItem Value="13">OFICIO DE ENTREGA DEL CUERPO</asp:ListItem>
                                        <asp:ListItem Value="14">OFICIO DE INCOMPETENCIA</asp:ListItem>
                                        <asp:ListItem Value="15">OFICIO PARA EL INSTITUTO DE VICTIMAS</asp:ListItem>
                                        <asp:ListItem Value="16">OFICIO PARA MEDIACION</asp:ListItem>
                                        <asp:ListItem Value="17">OFICIO PARA NOTIFICAR ACUERDO PARA ABSTENERSE DE INVESTIGAR</asp:ListItem>
                                        <asp:ListItem Value="18">OFICIO PARA NOTIFICAR INEJERCICIO</asp:ListItem>
                                        <asp:ListItem Value="19">OFICIO PARA QUE PERITO EN HECHOS DE TRANSITO IMPONGA DE ACTAS</asp:ListItem>
                                        <asp:ListItem Value="20">OFICIO PARA SOLICITAR EVOLUTIVO DE LESIONES</asp:ListItem>
                                        <asp:ListItem Value="21">OFICIO PARA SOLICITAR EXHORTO (IMPUTADO)</asp:ListItem>
                                        <asp:ListItem Value="22">OFICIO PARA SOLICITAR EXHORTO (TESTIGO)</asp:ListItem>
                                        <asp:ListItem Value="23">OFICIO PARA SOLICITAR EXPLORACION FISICA DE DETENIDO</asp:ListItem>
                                        <asp:ListItem Value="24">OFICIO PARA SOLICITAR FOTOGRAFIA</asp:ListItem>
                                        <asp:ListItem Value="25">OFICIO PARA SOLICITAR INFORME EN MATERIA DE GENETICA</asp:ListItem>
                                        <asp:ListItem Value="26">OFICIO PARA SOLICITAR INFORME MEDICO DE LESIONES</asp:ListItem>                                        
                                        <asp:ListItem Value="27">OFICIO PARA SOLICITAR INFORME PSICOLOGICO PARA MENOR</asp:ListItem>
                                        <asp:ListItem Value="28">OFICIO PARA SOLICITAR INFORME PSICOLOGICO</asp:ListItem>
                                        <asp:ListItem Value="29">OFICIO PARA SOLICITAR PERITO QUIMICO</asp:ListItem>
                                        <asp:ListItem Value="30">OFICIO PARA SOLICITAR PERITO VALUADOR Y FOTOGRAFIA</asp:ListItem>  
                                        <asp:ListItem Value="31">ORDEN CONTINUACION DE INVESTIGACION A LA POLICIA MINISTERIAL</asp:ListItem>                                      
                                        <asp:ListItem Value="32">ORDEN DE INVESTIGACION A LA POLICIA MINISTERIAL</asp:ListItem>                                       
                                        <asp:ListItem Value="33">OTRO FROMATO</asp:ListItem>
                                    --%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
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
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel38" runat="server" GroupingText="OTRO FORMATO" 
                    Visible="False">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label559" runat="server" Font-Bold="True" 
                                    Text="NOMBRE DEL FORMATO"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:TextBox ID="txtOtroFormato" runat="server" MaxLength="200" 
                                    style="text-transform :uppercase" Width="800px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="cmdGeneraPdf" runat="server" Font-Bold="True" Height="40px" 
                    onclick="cmdGeneraPdf_Click" Text="GENERAR DOCUMENTO" Visible="False" 
                    Width="214px" class="button" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                    <asp:Label ID="Label332" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Black" Text="SELECCIONE DOCUMENTO PDF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
               
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="28px" Width="353px" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                    <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstatus1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Red"></asp:Label>
                    <br />
                    <asp:Button ID="cmdGuardar" runat="server" Height="40px" 
                        onclick="cmdGuardar_Click" TabIndex="32" Text="GUARDAR DATOS" 
                        Width="156px" Font-Bold="True" class="button"  />
                    &nbsp;&nbsp;
                 

                    


                    <asp:Button ID="cmdReg" runat="server" Font-Bold="True" Height="40px" 
                        onclick="cmdReg_Click" TabIndex="32" Text="REGRESAR" Width="156px" class="button" />
                 

                    


                </td>
        </tr>
    </table>
   
    </ContentTemplate>
    </asp:UpdatePanel>
     
   
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;&nbsp;</td>
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
  
    
</div>

</asp:Content>
