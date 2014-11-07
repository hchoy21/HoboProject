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
        </form>
    </div>
    <link href="Content/css/Tables.css" rel="stylesheet" />
</asp:Content>
