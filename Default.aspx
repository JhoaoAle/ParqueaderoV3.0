<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextoHora" runat="server" Enabled="False"></asp:TextBox>
        <asp:Button ID="AumentarHora" runat="server" OnClick="AumentarHora_Click" Text="+" />
    </div>

</asp:Content>
