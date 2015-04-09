<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graphs.aspx.cs" Inherits="Hobo_Project.Graphs" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="page-header">
        <h1>Graphs</h1>
    </div>
    


    <link href="Content/css/hobo.css" rel="stylesheet" />
        <form runat="server">
            <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load">
                <Series>
                    <asp:Series Name="SeriesX">
                    </asp:Series>
                    <asp:Series Name="SeriesY">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
        </form>
</form>
</asp:Content>
