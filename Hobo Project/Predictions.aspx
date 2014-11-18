<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Predictions.aspx.cs" Inherits="Hobo_Project.Predictions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>Predictions</h1>
    </div>

    <div class="container">
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Literal ID="litResults" runat="server" visible="false"/><br />
                <h3>What do you predict the weather will be at FGCU.</h3>
                <asp:RadioButtonList ID="radVote" runat="server">
                    <asp:ListItem>Rain</asp:ListItem>
                    <asp:ListItem>Clear Skies</asp:ListItem>
                    <asp:ListItem>Sunny</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="butVote" 
                    runat="server" Text="Vote" onclick="butVote_Click" /><br />
                <asp:Label ID="lblStatus" runat="server" /><br />
                <asp:Button ID="butResults" runat="server" Text="Show Results" 
                    onclick="butResults_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    </div>
    <link href="Content/css/hobo.css" rel="stylesheet" />
</asp:Content>
