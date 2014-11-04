<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hobo_Project.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1 id="default-school">Florida Gulf Coast University</h1>
            <p></p>
            <h1>HOBO Weather Monitor</h1>
        </div>
    </div>


    <div class="container">
        <h1>Currrent Data Readings</h1>
        <div class="row">
            <div class="col-md-4">
                <h2>Pressure</h2>
                <p>pressure data</p>
            </div>
            <div class="col-md-4">
                <h2>Temperature</h2>
                <p>temperature data</p>
            </div>
            <div class="col-md-4">
                <h2>Humidity</h2>
                <p>humidity data</p>
            </div>
        </div>
    </div>

    <link href="Content/css/hobo.css" rel="stylesheet" type="text/css" />
</asp:Content>
