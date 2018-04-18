<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebHojadeAtencion.aspx.cs" Inherits="AtencionTemprana.WebHojadeAtencion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 298px;
            height: 119px;
            float: right;
        }
        .style8
        {
            font-family: Arial, Helvetica, sans-serif;
            text-align: left;
            font-size: x-large;
        }
        .style24
        {
            width: 594px;
            height: 23px;
        }
        .style26
        {
            width: 594px;
        }
        .style27
        {
            width: 73%;
        }
        .style28
        {
            width: 73%;
            height: 23px;
        }
        .style31
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style32
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
        .style33
        {
            width: 73%;
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-large;
        }
        .style34
        {
            width: 26%;
            height: 198px;
        }
        .style35
        {
            width: 594px;
            height: 198px;
        }
        .style36
        {
            width: 73%;
            height: 198px;
        }
        .style37
        {
            width: 22%;
            height: 198px;
        }
        .style13
        {
            width: 299px;
            height: 116px;
            text-align: center;
        }
        .style38
        {
            width: 26%;
            height: 160px;
        }
        .style39
        {
            width: 594px;
            height: 160px;
        }
        .style40
        {
            width: 73%;
            height: 160px;
        }
        .style41
        {
            width: 26%;
            height: 55px;
        }
        .style42
        {
            width: 594px;
            height: 55px;
        }
        .style43
        {
            width: 73%;
            height: 55px;
        }
        .style44
        {
            width: 26%;
        }
        .style45
        {
            font-family: Arial, Helvetica, sans-serif;
            width: 26%;
            text-align: right;
        }
        .style46
        {
            width: 26%;
            height: 23px;
        }
        .style47
        {
            width: 26%;
            height: 23px;
            font-family: Arial, Helvetica, sans-serif;
            text-align: right;
        }
    </style>
</head>
<body>
    
    
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div>
        
        <table style="width:100%;">
            <tr>
                <td class="style41">
                    <asp:Label ID="lblArbol" runat="server" Visible="False"></asp:Label>
                    </td>
                <td class="style42">
                    </td>
                <td class="style43" colspan="2">
                    </td>
            </tr>
            <tr>
                <td class="style34">
                    <img alt="" class="style3" src="img/PGJ_INICIO.jpg" align="middle" /></td>
                <td class="style35">
                    </td>
                <td class="style37">
                    </td>
                <td class="style36">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style33" colspan="2">
                    <strong style="text-align: left">HOJA DE ATENCION</strong></td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45">
                    <asp:Label ID="LblExpediente" runat="server" Text="NUC:"></asp:Label>
                </td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="LblNUC" runat="server" Text="NUC" Width="400px"
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif" 
                        ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style46">
                    </td>
                <td class="style24">
                    </td>
                <td class="style28" colspan="2">
                    </td>
            </tr>
            <tr>
                <td class="style47">
                    Unidad:</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style28" colspan="2">
                    <asp:Label ID="LblUnidad" runat="server" Text="Unidad" Width="800px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style46">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style28" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style47">
                    Municipio:</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style28" colspan="2">
                    <asp:Label ID="LblMunicipio" runat="server" Text="Municipio" Width="400px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style46">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style28" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style47">
                    Fecha de Inicio:</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style28" colspan="2">
                    <asp:Label ID="LblFechaInicio" runat="server" Text="FechaInicio" Width="400px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style46">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style28" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style46">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style28" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45">
                    Denunciante(s):</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="LblDenunciante" runat="server" Text="Denunciante" Width="600px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45">
                    Ofendido(s):</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="LblOfendido" runat="server" Text="Ofendido" Width="600px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45">
                    Imputado(s):</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="LblImputado" runat="server" Text="Imputado" Width="600px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45">
                    Delito(s):</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="LblDelito" runat="server" Text="Delito" Width="800px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45">
                    Le atendió:</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="LblUsuario" runat="server" Text="Usuario" Width="800px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style45">
                    Titular:</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Label ID="LblTitular" runat="server" Text="Titular" Width="600px" 
                        style="font-weight: 700; font-family: Arial, Helvetica, sans-serif"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style38">
                    </td>
                <td class="style39">
                    </td>
                <td class="style40" colspan="2">
                    <span class="style31">___________________________</span><br class="style31" />
                    <span class="style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    Firma del Titular</span><br class="style31" />
                    <br class="style31" />
                    <br class="style31" />
                    <br class="style31" />
                    <span class="style31">___________________________</span><br class="style31" />
                    <span class="style32">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    Sello de la Unidad</span></td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;</td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    &nbsp;<td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    <asp:Image runat="server" ID="QRImage" />
                </td>
            </tr>
            <tr>
                <td class="style44">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="&lt;&lt;" class="button" />
                </td>
                <td class="style26">
                    &nbsp;</td>
                <td class="style27" colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>

</ContentTemplate>
        </asp:UpdatePanel>
    </form>
    
    
</body>
</html>
