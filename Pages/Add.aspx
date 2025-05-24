<%@ Page Title="Yeni Personel Ekle" Language="C#" MasterPageFile="~/MasterPages/Site.master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="PERSO.Pages.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Yeni Personel Ekle</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <table>
        <tr>
            <td>Ad:</td>
            <td><asp:TextBox ID="txtAd" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Soyad:</td>
            <td><asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Resim:</td>
            <td>
                <asp:FileUpload ID="fuResim" runat="server" />
            </td>
        </tr>
        <tr>
        <td>Departman:</td>
        <td><asp:TextBox ID="txtDepartman" runat="server"></asp:TextBox></td>
    </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
