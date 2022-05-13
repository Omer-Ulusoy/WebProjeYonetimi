<%@ Page Title="" Language="C#" MasterPageFile="~/anaMasterPage.master" AutoEventWireup="true" CodeFile="AdminGiris.aspx.cs" Inherits="AdminGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <form runat="server">
        <section class="page-contain">
            <div class="contain">
                <div class="login-form">
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Lütfen Kullanıcı Bilgilerinizi Giriniz."></asp:Label>
                    <br />
                    <asp:TextBox ID="txtKullaniciAdi" runat="server" placeholder="Kullanıcı adınız..."></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtSifre" runat="server" placeholder="Şifreniz..." TextMode="Password" CssClass="txtSifre"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnGirisYap" runat="server" Text="Giriş Yap" class="button-default" OnClick="btnGirisYap_Click" />
                </div>
            </div>
        </section>
    </form>
</asp:Content>

