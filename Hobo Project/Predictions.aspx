<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Predictions.aspx.cs" Inherits="Hobo_Project.Predictions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Predictions</h1>
    </div>

    <div class="container">
        <form id="Form1" runat="server">
            <h1>What do you predict the weather will be at FGCU.</h1>
            <asp:RadioButton id="Rain" Text="Rain"
            GroupName="colors" runat="server"/>
            <br>
            <asp:RadioButton id="Clear" Text="Clear Skies"
            GroupName="colors" runat="server"/>
            <br>
            <asp:RadioButton id="Sunny" Text="Sunny" 
            GroupName="colors" runat="server"/>
            <br>
            <asp:Button ID="Button1" text="Submit" OnClick="submit" runat="server"/>
            <p><asp:Label id="confirm" runat="server"/></p>
        </form>
    </div>
    <link href="Content/css/hobo.css" rel="stylesheet" />
</asp:Content>
