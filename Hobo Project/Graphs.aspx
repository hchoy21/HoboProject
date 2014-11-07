<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graphs.aspx.cs" Inherits="Hobo_Project.Graphs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Graphs</h1>
    </div>
    <div class="embed-responsive-4by3">
        <iframe width="800" height="600" frameborder="0" seamless="seamless" scrolling="no" src="https://plot.ly/~hchoy7132/1/560/420"></iframe>
    </div>

    <link href="Content/css/hobo.css" rel="stylesheet" />
</asp:Content>
