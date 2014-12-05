<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Hobo_Project.Predictions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>About</h1>
    </div>

    <div class="container">
       <div class="panel-heading">
           <h2>Website</h2>
       </div>
        <p>This website displays the readings from the HOBO U30 for the following sensors: 
            Pressure (Hg), Temperature (c), and Relative Humidity. The readings are available 
            via tables and graphs. This website also hosts a prediction feature for users, 
            where users can predict what the weather will be like in Florida Gulf Coast University 
            for the next 4 hours. After 4 hours, the poll is reseted.</p>
       <div class="panel-heading">
           <h2>Project</h2>
       </div>
        <p>Project: The goal of the project was to collect data of the weather surrounding FGCU 
            campus and present this data to the Internet. The HOBO U30 is a protable weather station 
            that allows for weather data to be collected depending on the sensors it is equipped with. 
            The website was created so the data from the HOBO U30 can be more accessible and user-friendly.</p>
       <div class="panel-heading">
           <h2>HOBO Remote Weather Station</h2>
       </div>
        <p>The HOBO remote weather station was meant to be placed outside for a duration of time 
            before the user retreives its readings. So far, the only accessible means of retreiving 
            the data from the HOBO U30 is through wired connection.</p>
       <div class="panel-heading">
           <h2>Author</h2>
       </div>
        <p>The authors, Hendrik Choy, Richard Hernandez, and Nathan Nguyen are students 
            in the Software Engineering program at Florida Gulf Coast University</p>
    </div>

    <link href="Content/css/hobo.css" rel="stylesheet" />
</asp:Content>
