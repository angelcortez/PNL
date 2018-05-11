﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WDetailsPerson.aspx.cs" Inherits="AtencionTemprana.WDetailsPerson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                    <asp:Label ID="IdMunicipio" runat="server" Visible="FALSE"></asp:Label>
                <asp:Label ID="IdUnidad" runat="server" Visible="FALSE"></asp:Label>
                 <asp:Label ID="FI" runat="server" Visible="FALSE"></asp:Label>
                  <asp:Label ID="FF" runat="server" Visible="FALSE"></asp:Label>
    <div>
                <asp:GridView ID="gvEstados" runat="server" Height="118px" Width="1024px" 
        AutoGenerateColumns="False" DataSourceID="ObjectTabla" 
        CellPadding="4" ForeColor="#333333" GridLines="None"  >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ESTATUS" HeaderText="" ReadOnly="True" 
                SortExpression="ESTATUS" />
            <asp:BoundField DataField="ENERO" HeaderText="ENERO" ReadOnly="True" 
                SortExpression="ENERO" />
            <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" ReadOnly="True" 
                SortExpression="FEBRERO" />
            <asp:BoundField DataField="MARZO" HeaderText="MARZO" ReadOnly="True" 
                SortExpression="MARZO" />
            <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" ReadOnly="True" 
                SortExpression="ABRIL" />
            <asp:BoundField DataField="MAYO" HeaderText="MAYO" ReadOnly="True" 
                SortExpression="MAYO" />
            <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" ReadOnly="True" 
                SortExpression="JUNIO" />
            <asp:BoundField DataField="JULIO" HeaderText="JULIO" ReadOnly="True" 
                SortExpression="JULIO" />
            <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" ReadOnly="True" 
                SortExpression="AGOSTO" />
            <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" ReadOnly="True" 
                SortExpression="SEPTIEMBRE" />
            <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" ReadOnly="True" 
                SortExpression="OCTUBRE" />
            <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" ReadOnly="True" 
                SortExpression="NOVIEMBRE" />
            <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" ReadOnly="True" 
                SortExpression="DICIEMBRE" />
              <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" ReadOnly="True" 
                SortExpression="TOTAL" />
        </Columns>
            <EditRowStyle BackColor="#2461BF" />
   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                            Font-Size="Small" Font-Names="Arial" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" 
                HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Font-Size="Small" 
                            Font-Names="Arial" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" 
                ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
                    <asp:ObjectDataSource ID="ObjectTabla" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    
        
         TypeName="AtencionTemprana.dsReportesTableAdapters.SP_ConteoPNLTablaTableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="FI" Name="fechainicio" PropertyName="Text" 
                            Type="String" />
                        <asp:ControlParameter ControlID="FF" Name="fechafin" PropertyName="Text" 
                            Type="String" />
                        <asp:ControlParameter ControlID="IdMunicipio" DefaultValue="" 
                            Name="IdMunicipio" PropertyName="Text" Type="Int16" />
                        <asp:ControlParameter ControlID="IdUnidad" DefaultValue="" Name="IdUnidad" 
                            PropertyName="Text" Type="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    </form>
</body>
</html>