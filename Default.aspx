﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        Hora actual<br />
        <asp:TextBox ID="TextoHora" runat="server" Enabled="False"></asp:TextBox>
        <asp:Button ID="AumentarHora" runat="server" OnClick="AumentarHora_Click" Text="+" />
        <br />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="35px">
            Ingresar vehículo</asp:Panel>
        Placa<asp:Panel ID="Panel3" runat="server">
            <asp:TextBox ID="placa_text" runat="server"></asp:TextBox>
        </asp:Panel>
        <br />
        Casilla<asp:Panel ID="Panel4" runat="server">
            <asp:TextBox ID="casilla_in" runat="server" Width="28px"></asp:TextBox>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="False"></asp:PlaceHolder>
            <asp:Button ID="btn_ingresar" runat="server" OnClick="btn_ingresar_Click1" Text="Ingresar" />
            <asp:Panel ID="Panel5" runat="server" Height="29px">
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                <asp:Panel ID="Panel6" runat="server">
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                    <br />
                    <br />
                    <asp:Panel ID="Panel7" runat="server">
                        Retirar vehículo<br />
                        <asp:Panel ID="Panel8" runat="server">
                            Casilla<asp:Panel ID="Panel9" runat="server">
                                <asp:TextBox ID="casilla_out" runat="server" Width="24px"></asp:TextBox>
                                <asp:Button ID="btn_retirar" runat="server" OnClick="btn_retirar_Click" Text="Retirar" />
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </div>

</asp:Content>
