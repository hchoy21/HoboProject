<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graphs.aspx.cs" Inherits="Hobo_Project.Graphs" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="page-header">
        <h1>Graphs</h1>
    </div>

    <div class="container-fluid">
        <iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~hchoy7132/4.embed?width=640&height=480"></iframe>
        
    </div>

    <div class="container-fluid">
        <iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~hchoy7132/5.embed?width=640&height=480"></iframe>
    </div>

    <div class="container-fluid">
        <iframe width="640" height="480" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~hchoy7132/6.embed?width=640&height=480"></iframe>
    </div>


    <link href="Content/css/hobo.css" rel="stylesheet" />
</form>
</asp:Content>
