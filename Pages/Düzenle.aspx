<%@ Page Title="Personel Düzenle" Language="C#" MasterPageFile="~/MasterPages/Site.Master" 
    AutoEventWireup="true" CodeBehind="Düzenle.aspx.cs" Inherits="PERSO.Pages.Duzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align:center;">Personel Düzenle</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <asp:Panel ID="pnlForm" runat="server">
        
        <asp:HiddenField ID="hfPersonelID" runat="server" />
        <table style="margin: 0 auto;">
            <tr>
                <td>Ad:</td>
                <td><asp:TextBox ID="txtAd" runat="server" /></td>
            </tr>
            <tr>
                <td>Soyad:</td>
                <td><asp:TextBox ID="txtSoyad" runat="server" /></td>
            </tr>
            <tr>
                <td>Departman:</td>
                <td><asp:TextBox ID="txtDepartman" runat="server" /></td>
            </tr>
            <tr>
                <td>Resim:</td>
                <td>
                    
                    <asp:Image ID="imgResim" runat="server" Width="150px" Height="150px" /><br />
                   
                    <asp:FileUpload ID="fuResim" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center; padding-top:10px;">
                    <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />
                    <asp:Button ID="btnIptal" runat="server" Text="İptal" PostBackUrl="Default.aspx" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
