<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hobo_Project.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1 id="default-school">Florida Gulf Coast University</h1>
            <p></p>
            <h1>HOBO U30 Weather Monitor</h1>
        </div>
    </div>


    <div class="container">
        <h1>Latest Readings</h1>
        <div class="row">
            <div class="col-md-4">
                <h2>Pressure</h2>
                <p><asp:Label id="currentPressureLabel" runat="server"></asp:Label></p>
            </div>
            <div class="col-md-4">
                <h2>Temperature</h2>
                <p><asp:Label id="currentTemperatureLabel" runat="server"></asp:Label></p>
            </div>
            <div class="col-md-4">
                <h2>Humidity</h2>
                <p><asp:Label id="currentRHLabel" runat="server"></asp:Label></p>
            </div>
        </div>
    </div>

    <div class="container">
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <h3>What do you predict the weather will be at FGCU.</h3>
                        <asp:RadioButtonList ID="radVote" runat="server">
                            <asp:ListItem>Clear Skies</asp:ListItem>
                            <asp:ListItem>Light rain</asp:ListItem>
                            <asp:ListItem>Heavy rain</asp:ListItem>
                            <asp:ListItem>Cloudy hot</asp:ListItem>
                            <asp:ListItem>Cloudy warm</asp:ListItem>
                            <asp:ListItem>Cloudy cold</asp:ListItem>
                            <asp:ListItem>Sunny and Warm</asp:ListItem>
                            <asp:ListItem>Hot and humid</asp:ListItem>
                            <asp:ListItem>Sunny and cold</asp:ListItem>
                            <asp:ListItem>Foggy</asp:ListItem>
                            <asp:ListItem>Thunderstorm</asp:ListItem>
                            <asp:ListItem>Windy hot</asp:ListItem>
                            <asp:ListItem>Windy cold</asp:ListItem>
                            <asp:ListItem>Windy</asp:ListItem>

                        </asp:RadioButtonList>
                    </div>
                    <div class="col-md-6">
                        <asp:Literal ID="litResults" runat="server" visible="false"/><br />
                        <asp:Button ID="butVote" 
                            runat="server" Text="Vote" onclick="butVote_Click" /><br />
                        <asp:Label ID="lblStatus" runat="server" /><br /><br />
                        <asp:Button ID="butResults" runat="server" Text="Show Results" 
                            onclick="butResults_Click" />
                    </div>
                </div>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    </div>

    <link href="Content/css/hobo.css" rel="stylesheet" type="text/css" />
</asp:Content>
