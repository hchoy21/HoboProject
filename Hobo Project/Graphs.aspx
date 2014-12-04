<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graphs.aspx.cs" Inherits="Hobo_Project.Graphs" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Highcharts-4.0.1/js/highcharts.js" type="text/javascript"></script>

    <form id="form1" runat="server">
        <div class="page-header">
            <h1>Graphs</h1>
        </div>
        


        <div id="container" style="min-width: 248px; height: auto;">
            <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
        </div>



   
    </form>

    <link href="Content/css/hobo.css" rel="stylesheet" />

    
</asp:Content>

