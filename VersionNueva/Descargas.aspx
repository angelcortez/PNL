<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Descargas.aspx.cs" Inherits="AtencionTemprana.Descargas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
   <script type="text/javascript">
       function mostrarFichero(destino) {
           window.open(destino, null, "directories=no,height=600,width=800,left=0,top=0,location=no,menubar=yes,status=no,toolbar=yes,resizable=yes")
           document.forms(0).submit();
       }
   </script>      
        
<div id="main-wrapper">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Height="152px">
                <asp:Button ID="Button1" runat="server" Height="80px" onclick="Button1_Click" 
                    Text="Guardar Documento Generado" Width="240px" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    
    
</div>

</asp:Content>

