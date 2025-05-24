<%@ Page Title="Personel Listesi" Language="C#" MasterPageFile="~/MasterPages/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PERSO.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">Personel Listesi</h2>
    
    
    <div class="personnel-container">
        <asp:Repeater ID="rptPersonel" runat="server">
            <ItemTemplate>
                <div class="personnel-card">
                    <img src='<%# GetResimUrl(Eval("Resim")) %>' alt="Resim Yok" />
                    <div class="card-info">
                        <h3><%# Eval("Ad") %> <%# Eval("Soyad") %></h3>
                        <p>Departman: <%# Eval("Departman") %></p>
                        <div class="card-actions">
                            <a href="Düzenle.aspx?id=<%# Eval("PersonelID") %>">Düzenle</a>
                            <a href="Delete.aspx?id=<%# Eval("PersonelID") %>" onclick="return confirm('Bu kişiyi silmek istediğinizden emin misiniz?');">Sil</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
    <br />
    <a href="Add.aspx" class="add-new-btn">Yeni Personel Ekle</a>
</asp:Content>
