<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.master"
         CodeBehind="Detay.aspx.cs" Inherits="PERSO.Pages.Detay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: flex; justify-content: center; margin-top: 30px;">
        <div style="text-align: center; border:1px solid #ccc; padding:20px;">
            <asp:Image ID="imgResim" runat="server" Width="300" Height="300" />
            <h2>
                <asp:Label ID="lblAd" runat="server"></asp:Label>
                <asp:Label ID="lblSoyad" runat="server"></asp:Label>
            </h2>
            <p>
                Departman: <asp:Label ID="lblDepartman" runat="server"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>
