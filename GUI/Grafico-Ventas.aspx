<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="Grafico-Ventas.aspx.cs" Inherits="GUI.Grafico_Ventas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Chart ID="Chart1" runat="server" Height="286px" Width="420px">
            <legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" 
                LegendStyle="Row" Name="Default" />
            </legends>
            <series>
                <asp:Series Name="Series1" ChartType="Pie" Label="#VAL{N}" LabelToolTip="#VALX" LegendText="#VALX" LegendToolTip="#VAL{N}"></asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </div>
</asp:Content>
