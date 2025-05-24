<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Site.Master" CodeBehind="Slider.aspx.cs" Inherits="PERSO.Pages.Slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <%-- <h2 class="slider-title">Resim Slider</h2>--%>

    <style>
        .slider {
            position: relative;
            width: 1100px;
            height: 400px;
            margin: 20px auto;
            overflow: hidden;
            border: 3px solid #001f3f;
            border-radius: 8px;
            background-color: #f5f5dc;
        }

        .slide {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            opacity: 0;
            animation: fade 20s infinite;
        }

        @keyframes fade {
            0% { opacity: 0; }
            5% { opacity: 1; }
            25% { opacity: 1; }
            30% { opacity: 0; }
            100% { opacity: 0; }
        }

        .slider img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

        .slider-title {
            text-align: center;
            color: #001f3f;
            font-size: 1.8rem;
            margin-bottom: 10px;
        }
    </style>

    <div class="slider">
        <asp:Repeater ID="rptSlider" runat="server">
            <ItemTemplate>
                <div class="slide" style='animation-delay: <%# (Container.ItemIndex * 5) %>s;'>
                    <img src='<%# ((PERSO.Pages.Slider)Page).GetResimUrl(Eval("Resim")) %>' alt="Slide Resim" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
