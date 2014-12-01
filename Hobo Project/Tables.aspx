<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tables.aspx.cs" Inherits="Hobo_Project.Tables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Tables</h1>
    </div>
     <div class="container">

        <form id ="form1" runat="server">
            <div class="readouts-container">
                <div class="panel panel-default">
                    <div class="panel-heading">Readouts</div>
                    <asp:GridView ID="GridView1" 
                        onrowdatabound="GridView1_RowDataBound" 
                        autogeneratecolumns="True" 
                        runat="server" CssClass="table table-hover" SortedDescendingHeaderStyle-Wrap="False"></asp:GridView>
                </div>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <asp:Label ID="searchTitle" Text="Search For Entries" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="searchDateLabel" runat="server" Text="Date"></asp:Label>
                    <asp:TextBox ID="searchDateBeginTB" runat="server"></asp:TextBox>
                    <asp:TextBox ID="searchDateEndTB" runat="server"></asp:TextBox>
                    <p>Enter a date (mm/dd/yy) ignore the time</p>
                    <br />
                    <asp:Label ID="searchStatusLabel" runat="server"></asp:Label>

                    <asp:Button ID="searchButton" Text="Search" runat="server" OnClick="searchButton_Click" />
                </div>
            </div>
        </form>
    </div>
    <link href="Content/css/hobo.css" rel="stylesheet" />
</asp:Content>
