<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.Master" 
         CodeBehind="AnaSayfa.aspx.cs" Inherits="PERSO.Pages.AnaSayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="gallery-title">Resim Galerisi</h2>
    
    <div class="gallery-container">
        <asp:Repeater ID="rptResimler" runat="server">
            <ItemTemplate>
                <div class="gallery-item">
                    <a href='Detay.aspx?id=<%# Eval("PersonelID") %>'>
                        <img src='<%# GetResimUrl(Eval("Resim")) %>' alt="Resim Yok" />
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
